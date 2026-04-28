using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Usuario;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class UsuarioBusinessMapper
{
    public static UsuarioDataModel ToDataModel(CrearUsuarioRequest request)
    {
        return new UsuarioDataModel
        {
            Login = request.Login,
            PasswordHash = request.Password
        };
    }

    public static UsuarioDataModel ToDataModel(ActualizarUsuarioRequest request)
    {
        return new UsuarioDataModel
        {
            Id = request.Id,
            Login = request.Login,
            PasswordHash = string.IsNullOrWhiteSpace(request.Password)
                ? string.Empty
                : request.Password
        };
    }

    public static UsuarioResponse ToResponse(UsuarioDataModel model)
    {
        return new UsuarioResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Login = model.Login,
            Roles = model.Roles
        };
    }
}   