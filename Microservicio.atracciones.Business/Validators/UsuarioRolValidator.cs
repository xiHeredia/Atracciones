using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.UsuarioRol;

namespace Microservicio.atracciones.Business.Validators;

public static class UsuarioRolValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearUsuarioRolRequest request)
    {
        var errors = new List<string>();

        if (request.UsuarioId <= 0)
            errors.Add("El id del usuario es inválido.");

        if (request.RolId <= 0)
            errors.Add("El id del rol es inválido.");

        return errors;
    }
}