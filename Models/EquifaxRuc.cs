using System;
using System.Collections.Generic;

namespace ApiProject3.Models
{
    public partial class EquifaxRuc
    {
        public int Id { get; set; }
        public int Ruc { get; set; }
        public DateTime FechaCreacionRuc { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPa { get; set; } = null!;
        public string ApellidoMa { get; set; } = null!;
        public int ScoreCrediticio { get; set; }
        public string Deuda { get; set; } = null!;
        public int IdServicio { get; set; }

        public virtual Servicio IdServicioNavigation { get; set; } = null!;
    }
}
