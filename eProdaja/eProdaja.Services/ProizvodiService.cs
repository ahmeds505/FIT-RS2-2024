using eProdaja.Model;
using eProdaja.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : IProizvodiService
    {
        public EProdajaContext Context { get; set; }
        public ProizvodiService(EProdajaContext context) 
        {
                Context = context;
        }
        
        public virtual List<Model.Proizvodi> GetList()
        {
            var list = Context.Proizvodi.ToList();
            var result = new List<Model.Proizvodi>();

            foreach (var item in list)
            {
                result.Add(new Model.Proizvodi()
                {
                    Cijena = item.Cijena,
                    Naziv = item.Naziv,
                    ProizvodId = item.ProizvodId
                });
            }

            return result;
        }
    }
}
