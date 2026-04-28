using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Idioma;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class IdiomaBusinessMapper
{
    public static IdiomaDataModel ToDataModel(CrearIdiomaRequest request)
    {
        return new IdiomaDataModel
        {
            Nombre = request.Nombre
        };
    }

    public static IdiomaDataModel ToDataModel(ActualizarIdiomaRequest request)
    {
        return new IdiomaDataModel
        {
            Id = request.Id,
            Nombre = request.Nombre
        };
    }

    public static IdiomaResponse ToResponse(IdiomaDataModel model)
    {
        return new IdiomaResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Nombre = model.Nombre
        };
    }
}