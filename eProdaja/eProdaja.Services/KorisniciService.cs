﻿using eProdaja.Model;
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
using Microsoft.Extensions.Logging;

namespace eProdaja.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnici, KorisniciSearchObject, Database.Korisnici, KorisniciInsert, KorisniciUpdate>, IKorisniciService
    {
        ILogger<KorisniciService> _logger;
        public KorisniciService(EProdajaContext context, IMapper mapper, ILogger<KorisniciService> logger) : base(context, mapper)
        {
           _logger = logger;
        }

        public override IQueryable<Database.Korisnici> AddFilter(KorisniciSearchObject searchObject, IQueryable<Database.Korisnici> query)
        {
            query = base.AddFilter(searchObject, query);

            if (!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
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

            if (searchObject.IsKorisniciUlogeIncluded == true)
            {
                query = query.Include(x => x.KorisniciUloge).ThenInclude(x => x.Uloga);
            }

            return query;
        }

        public override void BeforeInsert(KorisniciInsert request, Database.Korisnici entity)
        {
            _logger.LogInformation($"Adding user: {entity.KorisnickoIme}");

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }



            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            base.BeforeInsert(request, entity);
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

        public override void BeforeUpdate(KorisniciUpdate request, Database.Korisnici entity)
        {
            base.BeforeUpdate(request, entity);

            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
        }

        public Model.Korisnici Login(string username, string password)
        {
            var entity = Context.Korisnici.Include(x=>x.KorisniciUloge).ThenInclude(x=>x.Uloga).FirstOrDefault(x => x.KorisnickoIme == username);


            if(entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.LozinkaSalt, password);

            if(hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<Model.Korisnici>(entity);
        }
    }
}
