using eProdaja.Model;
<<<<<<< Updated upstream
=======
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
>>>>>>> Stashed changes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseService<Model.Proizvodi, ProizvodiSearchObject, Database.Proizvodi>, IProizvodiService
    {
<<<<<<< Updated upstream
        public new List<Proizvodi> List = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodId = 1,
                Naziv = "Laptop",
                Cijena = 999
            },
            new Proizvodi()
            {
                ProizvodId = 2,
                Naziv = "Monitor",
                Cijena = 450
            }
        };
        public virtual List<Proizvodi> GetList()
        {
            return List;
=======
        
        public ProizvodiService(EProdajaContext context, IMapper mapper) : base(context, mapper)
        {
           
        }

        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.FTS));
            }

            return filteredQuery;
>>>>>>> Stashed changes
        }
    }
}
