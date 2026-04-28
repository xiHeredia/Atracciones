using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.AtraccionIncluye;

namespace Microservicio.atracciones.Business.Validators;

public static class AtraccionIncluyeValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearAtraccionIncluyeRequest request)
    {
        var errors = new List<string>();

        if (request.AtId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.IncId <= 0)
            errors.Add("El id de incluye es inválido.");

        return errors;
    }
}