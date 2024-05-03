using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class Izlazi
    {
        public int IzlazId { get; set; }

        public string BrojRacuna { get; set; } = null!;

        public DateTime Datum { get; set; }

        public int KorisnikId { get; set; }

        public bool Zakljucen { get; set; }

        public decimal IznosBezPdv { get; set; }

        public decimal IznosSaPdv { get; set; }

        public int? NarudzbaId { get; set; }

        public int SkladisteId { get; set; }

        public virtual ICollection<IzlazStavke> IzlazStavke { get; set; } = new List<IzlazStavke>();

        public virtual Korisnici Korisnik { get; set; } = null!;

        public virtual Narudzbe? Narudzba { get; set; }

        public virtual Skladiste Skladiste { get; set; } = null!;
    }
}
