using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Cliente;

namespace Microservicio.atracciones.Business.Validators;

public static class ClienteValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearClienteRequest request)
    {
        var errors = new List<string>();

        if (request.UsuarioId <= 0)
            errors.Add("El id del usuario es inválido.");

        if (string.IsNullOrWhiteSpace(request.TipoIdentificacion))
            errors.Add("El tipo de identificación es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.NumeroIdentificacion))
            errors.Add("El número de identificación es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Nombres))
            errors.Add("Los nombres son obligatorios.");

        if (string.IsNullOrWhiteSpace(request.Apellidos))
            errors.Add("Los apellidos son obligatorios.");

        if (string.IsNullOrWhiteSpace(request.Correo))
            errors.Add("El correo es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarClienteRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del cliente es inválido.");

        if (request.UsuarioId <= 0)
            errors.Add("El id del usuario es inválido.");

        if (string.IsNullOrWhiteSpace(request.TipoIdentificacion))
            errors.Add("El tipo de identificación es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.NumeroIdentificacion))
            errors.Add("El número de identificación es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Nombres))
            errors.Add("Los nombres son obligatorios.");

        if (string.IsNullOrWhiteSpace(request.Apellidos))
            errors.Add("Los apellidos son obligatorios.");

        if (string.IsNullOrWhiteSpace(request.Correo))
            errors.Add("El correo es obligatorio.");

        return errors;
    }
}