using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class UsuarioRolEntity
    {
        public int UsuarioRolID { get; set; }

        public int UsuarioAppID { get; set; }

        public int RolID { get; set; }

        public bool EsEliminado { get; set; }

        public string CreadoPorUsuario { get; set; } = null!;

        public DateTime FechaRegistroUtc { get; set; }

        public string? ModificadoDesdeIP { get; set; }

        public byte[] RowVersion { get; set; }

        /* =========================
           RELACIONES
        ========================= */

        public UsuarioAppEntity UsuarioApp { get; set; } = null!;

        public RolEntity Rol { get; set; } = null!;
    }
}