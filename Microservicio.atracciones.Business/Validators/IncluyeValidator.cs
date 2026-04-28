using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Incluye;

namespace Microservicio.atracciones.Business.Validators;

public static class IncluyeValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearIncluyeRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Descripcion))
            errors.Add("La descripción de incluye es obligatoria.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarIncluyeRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de incluye es inválido.");

        if (string.IsNullOrWhiteSpace(request.Descripcion))
            errors.Add("La descripción de incluye es obligatoria.");

        return errors;
    }
}