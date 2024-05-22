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
    public class DraftProizvodiState : BaseProizvodiState
    {
        public DraftProizvodiState(EProdajaContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override Model.Proizvodi Update(int id, ProizvodiUpdate request)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            Mapper.Map(request, entity);

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

        public override Model.Proizvodi Activate(int id)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "active";

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

        public override Model.Proizvodi Hide(int id)
        {
            var set = Context.Set<Database.Proizvodi>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();

            return Mapper.Map<Model.Proizvodi>(entity);
        }

        public override List<string> AllowedActions(Proizvodi entity)
        {
            return new List<string>() { nameof(Activate), nameof(Update), nameof(Hide) };
        }
    }
}
