using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.UsuarioRol;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class UsuarioRolBusinessMapper
{
    public static UsuarioRolDataModel ToDataModel(CrearUsuarioRolRequest request)
    {
        return new UsuarioRolDataModel
        {
            UsuarioId = request.UsuarioId,
            RolId = request.RolId
        };
    }

    public static UsuarioRolResponse ToResponse(UsuarioRolDataModel model)
    {
        return new UsuarioRolResponse
        {
            UsuarioRolId = model.UsuarioRolId,
            UsuarioId = model.UsuarioId,
            RolId = model.RolId,
            RolDescripcion = model.RolDescripcion
        };
    }
}