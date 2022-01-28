using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignitis.Models
{
    public class Klasifik
    {
        public long? KlasifikId { get; set; }

        public string Pavadinimas { get; set; }

        public long? Tipas { get; set; }
    }
}