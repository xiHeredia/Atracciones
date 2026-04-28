using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Destino;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class DestinoBusinessMapper
{
    public static DestinoDataModel ToDataModel(CrearDestinoRequest request)
    {
        return new DestinoDataModel
        {
            Nombre = request.Nombre,
            Pais = request.Pais,
            ImagenUrl = request.ImagenUrl
        };
    }

    public static DestinoDataModel ToDataModel(ActualizarDestinoRequest request)
    {
        return new DestinoDataModel
        {
            Id = request.Id,
            Nombre = request.Nombre,
            Pais = request.Pais,
            ImagenUrl = request.ImagenUrl
        };
    }

    public static DestinoResponse ToResponse(DestinoDataModel model)
    {
        return new DestinoResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Nombre = model.Nombre,
            Pais = model.Pais,
            ImagenUrl = model.ImagenUrl
        };
    }
}