using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class UsuarioRolDataMapper
{
    public static UsuarioRolDataModel ToModel(UsuarioRolEntity entity)
    {
        return new UsuarioRolDataModel
        {
            UsuarioRolId = entity.UsuRolId,
            UsuarioId = entity.UsuId,
            RolId = entity.RolId,
            RolDescripcion = entity.Rol?.RolDescripcion
        };
    }
}