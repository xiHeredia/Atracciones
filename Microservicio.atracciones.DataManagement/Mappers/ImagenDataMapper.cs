using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ImagenDataMapper
{
    public static ImagenDataModel ToModel(ImagenEntity entity)
    {
        return new ImagenDataModel
        {
            Id = entity.ImgId,
            Guid = entity.ImgGuid,
            Url = entity.ImgUrl,
            Descripcion = entity.ImgDescripcion
        };
    }
}