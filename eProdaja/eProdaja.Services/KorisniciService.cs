using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        
        public virtual List<Model.Korisnici> GetList()
        {
            var list = Context.Korisnici.ToList();
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            //foreach (var item in list) 
            //{
            //    result.Add(new Model.Korisnici()
            //    {
            //        KorisnikId = item.KorisnikId,
            //        Ime = item.Ime,
            //        Prezime = item.Prezime,
            //        Email = item.Email,
            //        Telefon = item.Telefon,
            //        KorisnickoIme = item.KorisnickoIme,
            //        Status = item.Status
            //    });
            //}

            result = Mapper.Map(list, result);

            return result;
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
