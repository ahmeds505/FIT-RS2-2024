using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class Proizvodi
    {
        public int ProizvodId { get; set; }

        public string Naziv { get; set; } = null!;

        public string Sifra { get; set; } = null!;

        public decimal Cijena { get; set; }

        public int VrstaId { get; set; }

        public int JedinicaMjereId { get; set; }

        public byte[]? Slika { get; set; }

        public byte[]? SlikaThumb { get; set; }

        public bool? Status { get; set; }

        public string? StateMachine { get; set; }

        public virtual ICollection<IzlazStavke> IzlazStavke { get; set; } = new List<IzlazStavke>();

        public virtual JediniceMjere JedinicaMjere { get; set; } = null!;

        public virtual ICollection<NarudzbaStavke> NarudzbaStavke { get; set; } = new List<NarudzbaStavke>();

        public virtual ICollection<Ocjene> Ocjene { get; set; } = new List<Ocjene>();

        public virtual ICollection<UlazStavke> UlazStavke { get; set; } = new List<UlazStavke>();

        public virtual VrsteProizvoda Vrsta { get; set; } = null!;
    }
}
