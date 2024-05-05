using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class VrsteProizvodaService : BaseService<Model.VrsteProizvoda, VrsteProizvodaSearchObject, Database.VrsteProizvoda>, IVrsteProizvodaService
    {
       
        public VrsteProizvodaService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public override IQueryable<Database.VrsteProizvoda> AddFilter(VrsteProizvodaSearchObject search, IQueryable<Database.VrsteProizvoda> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return filteredQuery;
        }
    }
}
