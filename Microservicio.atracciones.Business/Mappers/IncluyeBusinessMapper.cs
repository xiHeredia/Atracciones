using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Incluye;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class IncluyeBusinessMapper
{
    public static IncluyeDataModel ToDataModel(CrearIncluyeRequest request)
    {
        return new IncluyeDataModel
        {
            Descripcion = request.Descripcion
        };
    }

    public static IncluyeDataModel ToDataModel(ActualizarIncluyeRequest request)
    {
        return new IncluyeDataModel
        {
            Id = request.Id,
            Descripcion = request.Descripcion
        };
    }

    public static IncluyeResponse ToResponse(IncluyeDataModel model)
    {
        return new IncluyeResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Descripcion = model.Descripcion
        };
    }
}