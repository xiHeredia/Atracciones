using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ImagenAtraccionDataMapper
{
    public static ImagenAtraccionDataModel ToModel(ImagenAtraccionEntity entity)
    {
        return new ImagenAtraccionDataModel
        {
            AtId = entity.AtId,
            ImgId = entity.ImgId,
            ImagenUrl = entity.Imagen?.ImgUrl,
            ImagenDescripcion = entity.Imagen?.ImgDescripcion
        };
    }
}