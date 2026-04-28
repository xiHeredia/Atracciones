using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ImagenAtraccion;

namespace Microservicio.atracciones.Business.Validators;

public static class ImagenAtraccionValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearImagenAtraccionRequest request)
    {
        var errors = new List<string>();

        if (request.AtId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.ImgId <= 0)
            errors.Add("El id de la imagen es inválido.");

        return errors;
    }
}