using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.Database
{
    public partial class Dobavljaci
    {
        public int DobavljacId { get; set; }

        public string Naziv { get; set; } = null!;

        public string? KontaktOsoba { get; set; }

        public string Adresa { get; set; } = null!;

        public string Telefon { get; set; } = null!;

        public string? Fax { get; set; }

        public string? Web { get; set; }

        public string Email { get; set; } = null!;

        public string? ZiroRacuni { get; set; }

        public string? Napomena { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Ulazi> Ulazi { get; set; } = new List<Ulazi>();
    }
}
