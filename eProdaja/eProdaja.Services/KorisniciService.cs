using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        public EProdajaContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public KorisniciService(EProdajaContext context, IMapper mapper) 
        {
            Context = context;
            Mapper = mapper;
        }
        
        public virtual eProdaja.Model.PagedResult<Model.Korisnici> GetList(KorisniciSearchObject searchObject)
        {
            var query = Context.Korisnici.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x => x.Ime.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Email))
            {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == searchObject.KorisnickoIme);
            }

            if(searchObject.IsKorisniciUlogeIncluded == true)
            {
                query = query.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga);
            }

            int count = query.Count();

            if (!string.IsNullOrWhiteSpace(searchObject.OrderBy))
            {

            }

            if(searchObject.Page.HasValue == true && searchObject.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
            }

            var list = query.ToList();
            
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            result = Mapper.Map(list, result);

            eProdaja.Model.PagedResult<Model.Korisnici> response = new eProdaja.Model.PagedResult<Model.Korisnici>();

            response.ResultList = result;
            response.Count = count;

            return response;
        }

        public Model.Korisnici Insert(KorisniciInsert item)
        {
            if(item.Lozinka != item.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            Database.Korisnici entity = new Database.Korisnici();
            Mapper.Map(item, entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, item.Lozinka);

            Context.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var byteArray = RNGCryptoServiceProvider.GetBytes(16);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnici Update(int id, KorisniciUpdate item)
        {
            var entity = Context.Korisnici.Find(id);

            Mapper.Map(item, entity);

            if(item.Lozinka != null)
            {
                if (item.Lozinka != item.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, item.Lozinka);
            }

            Context.SaveChanges();

            return Mapper.Map<Model.Korisnici>(entity);
        }
    }
}
