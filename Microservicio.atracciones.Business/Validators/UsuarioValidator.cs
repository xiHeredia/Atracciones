using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Usuario;

namespace Microservicio.atracciones.Business.Validators;

public static class UsuarioValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearUsuarioRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Login))
            errors.Add("El login es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Password))
            errors.Add("La contraseña es obligatoria.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarUsuarioRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del usuario es inválido.");

        if (string.IsNullOrWhiteSpace(request.Login))
            errors.Add("El login es obligatorio.");

        return errors;
    }
}