using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, ProizvodiSearchObject, Database.Proizvodi, ProizvodiInsert, ProizvodiUpdate>, IProizvodiService
    {
        public BaseProizvodiState BaseProizvodiState { get; set; }
        public ProizvodiService(EProdajaContext context, IMapper mapper, BaseProizvodiState baseProizvodiState) : base(context, mapper)
        {
            BaseProizvodiState = baseProizvodiState;
        }


        public override IQueryable<Database.Proizvodi> AddFilter(ProizvodiSearchObject search, IQueryable<Database.Proizvodi> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.FTS));
            }

            return filteredQuery;
        }

        public override Model.Proizvodi Insert(ProizvodiInsert request)
        {
            var state = BaseProizvodiState.CreateState("initial");

            return state.Insert(request);
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdate request)
        {
            var entity = GetById(id);

            var state = BaseProizvodiState.CreateState(entity.StateMachine);

            return state.Update(id, request);
        }

        public Model.Proizvodi Activate(int id)
        {
            var entity = GetById(id);

            var state = BaseProizvodiState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }
    }
}
