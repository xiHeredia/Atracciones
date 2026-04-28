using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Idioma;

namespace Microservicio.atracciones.Business.Validators;

public static class IdiomaValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearIdiomaRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre del idioma es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarIdiomaRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del idioma es inválido.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre del idioma es obligatorio.");

        return errors;
    }
}