using System;
using System.Collections.Generic;

namespace ApiProject3.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            EquifaxRucs = new HashSet<EquifaxRuc>();
        }

        public int IdServicio { get; set; }
        public int? Ruc { get; set; }
        public int? Dni { get; set; }
        public int? Ce { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<EquifaxRuc> EquifaxRucs { get; set; }
    }
}
