using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class ClienteEntity
    {
        public int ClienteID { get; set; }

        public Guid ClienteGuid { get; set; }

        public string TipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? RazonSocial { get; set; }

        public string EstadoCliente { get; set; }

        public bool EsEliminado { get; set; }

        public string CreadoPorUsuario { get; set; }

        public DateTime FechaRegistroUtc { get; set; }

        public string? ModificadoDesdeIP { get; set; }

        public byte[] RowVersion { get; set; }
    }
}