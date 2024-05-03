using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class IzlazStavke
    {
        public int IzlazStavkaId { get; set; }

        public int IzlazId { get; set; }

        public int ProizvodId { get; set; }

        public int Kolicina { get; set; }

        public decimal Cijena { get; set; }

        public decimal? Popust { get; set; }

        public virtual Izlazi Izlaz { get; set; } = null!;

        public virtual Proizvodi Proizvod { get; set; } = null!;
    }
}
