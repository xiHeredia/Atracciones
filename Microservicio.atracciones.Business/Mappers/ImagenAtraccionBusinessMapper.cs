using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ImagenAtraccion;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ImagenAtraccionBusinessMapper
{
    public static ImagenAtraccionDataModel ToDataModel(CrearImagenAtraccionRequest request)
    {
        return new ImagenAtraccionDataModel
        {
            AtId = request.AtId,
            ImgId = request.ImgId
        };
    }

    public static ImagenAtraccionResponse ToResponse(ImagenAtraccionDataModel model)
    {
        return new ImagenAtraccionResponse
        {
            AtId = model.AtId,
            ImgId = model.ImgId,
            ImagenUrl = model.ImagenUrl,
            ImagenDescripcion = model.ImagenDescripcion
        };
    }
}