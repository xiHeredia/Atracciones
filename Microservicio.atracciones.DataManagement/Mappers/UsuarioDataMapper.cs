using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class UsuarioDataMapper
{
    public static UsuarioDataModel ToModel(UsuarioEntity entity)
    {
        return new UsuarioDataModel
        {
            Id = entity.UsuId,
            Guid = entity.UsuGuid,
            Login = entity.UsuLogin,
            PasswordHash = entity.UsuPasswordHash,
            Roles = entity.UsuarioRoles
                .Where(x => x.UsuRolEstado == "A" && x.Rol.RolEstado == "A")
                .Select(x => x.Rol.RolDescripcion)
                .ToList()
        };
    }
}