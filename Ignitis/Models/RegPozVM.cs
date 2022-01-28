using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignitis.Models
{
    public class RegPozVM
    {
        // Registravimo pozymiu klasifikatorius
        public long RegPozId { get; set; }

        public string Pavadinimas { get; set; }

        public long Tipas { get; set; }

        public List<Klasifik> Klasifikatorius { get; set; } // Dropdauno itemai

        public long? KlasifikId { get; set; } // Pasirinkta dropdauno reikšmė

        public long? RegPozKlasifikId { get; set; } // Duomenų eilutės ID

    }
}