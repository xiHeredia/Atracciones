using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class AuditoriaEntity
    {
        public long AuditoriaID { get; set; }

        public string Tabla { get; set; } = null!;

        public string TipoOperacion { get; set; } = null!;

        public string? Usuario { get; set; }

        public DateTime FechaEventoUtc { get; set; }

        public string? IpOrigen { get; set; }

        public string? DatosAntes { get; set; }

        public string? DatosDespues { get; set; }
    }
}