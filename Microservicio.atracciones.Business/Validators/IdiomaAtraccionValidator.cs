using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;

namespace Microservicio.atracciones.Business.Validators;

public static class IdiomaAtraccionValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearIdiomaAtraccionRequest request)
    {
        var errors = new List<string>();

        if (request.AtId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.IdId <= 0)
            errors.Add("El id del idioma es inválido.");

        return errors;
    }
}