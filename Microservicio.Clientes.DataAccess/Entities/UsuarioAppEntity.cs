using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio.Clientes.DataAccess.Entities
{
    public class UsuarioAppEntity
    {
        public int UsuarioAppID { get; set; }

        public Guid UsuarioGuid { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public bool EsEliminado { get; set; }

        public string CreadoPorUsuario { get; set; } = null!;

        public DateTime FechaRegistroUtc { get; set; }

        public string? ModificadoDesdeIP { get; set; }

        public byte[] RowVersion { get; set; }

        /* =========================
           RELACIONES
        ========================= */

        // Relación con UsuarioRol (muchos roles por usuario)
        public ICollection<UsuarioRolEntity> UsuarioRoles { get; set; } = new List<UsuarioRolEntity>();
    }
}