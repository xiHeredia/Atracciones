using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Imagen;

namespace Microservicio.atracciones.Business.Validators;

public static class ImagenValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearImagenRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Url))
            errors.Add("La URL de la imagen es obligatoria.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarImagenRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la imagen es inválido.");

        if (string.IsNullOrWhiteSpace(request.Url))
            errors.Add("La URL de la imagen es obligatoria.");

        return errors;
    }
}