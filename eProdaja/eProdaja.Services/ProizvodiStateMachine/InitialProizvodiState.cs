using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class InitialProizvodiState : BaseProizvodiState
    {
        public InitialProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider) 
        {
            
        }

        public override Model.Proizvodi Insert(ProizvodiInsert request)
        {
            var set = Context.Set<Proizvodi>();
            var entity = Mapper.Map<Proizvodi>(request);

            entity.StateMachine = "draft";

            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

    }
}
