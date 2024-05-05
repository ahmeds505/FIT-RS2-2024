using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class JediniceMjere
    {
        public int JedinicaMjereId { get; set; }

        public string Naziv { get; set; } = null!;

        public virtual ICollection<Proizvodi> Proizvodi { get; set; } = new List<Proizvodi>();
    }
}
