using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Rol;

namespace Microservicio.atracciones.Business.Validators;

public static class RolValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearRolRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Descripcion))
            errors.Add("La descripción del rol es obligatoria.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarRolRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del rol es inválido.");

        if (string.IsNullOrWhiteSpace(request.Descripcion))
            errors.Add("La descripción del rol es obligatoria.");

        return errors;
    }
}