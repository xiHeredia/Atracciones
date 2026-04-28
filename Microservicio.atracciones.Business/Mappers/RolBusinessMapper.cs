using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Rol;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class RolBusinessMapper
{
    public static RolDataModel ToDataModel(CrearRolRequest request)
    {
        return new RolDataModel
        {
            Descripcion = request.Descripcion
        };
    }

    public static RolDataModel ToDataModel(ActualizarRolRequest request)
    {
        return new RolDataModel
        {
            Id = request.Id,
            Descripcion = request.Descripcion
        };
    }

    public static RolResponse ToResponse(RolDataModel model)
    {
        return new RolResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Descripcion = model.Descripcion
        };
    }
}