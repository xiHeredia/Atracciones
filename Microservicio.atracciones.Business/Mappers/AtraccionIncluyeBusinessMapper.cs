using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.AtraccionIncluye;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class AtraccionIncluyeBusinessMapper
{
    public static AtraccionIncluyeDataModel ToDataModel(CrearAtraccionIncluyeRequest request)
    {
        return new AtraccionIncluyeDataModel
        {
            AtId = request.AtId,
            IncId = request.IncId
        };
    }

    public static AtraccionIncluyeResponse ToResponse(AtraccionIncluyeDataModel model)
    {
        return new AtraccionIncluyeResponse
        {
            AtId = model.AtId,
            IncId = model.IncId,
            IncluyeDescripcion = model.IncluyeDescripcion
        };
    }
}