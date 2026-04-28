using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Imagen;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ImagenBusinessMapper
{
    public static ImagenDataModel ToDataModel(CrearImagenRequest request)
    {
        return new ImagenDataModel
        {
            Url = request.Url,
            Descripcion = request.Descripcion
        };
    }

    public static ImagenDataModel ToDataModel(ActualizarImagenRequest request)
    {
        return new ImagenDataModel
        {
            Id = request.Id,
            Url = request.Url,
            Descripcion = request.Descripcion
        };
    }

    public static ImagenResponse ToResponse(ImagenDataModel model)
    {
        return new ImagenResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Url = model.Url,
            Descripcion = model.Descripcion
        };
    }
}