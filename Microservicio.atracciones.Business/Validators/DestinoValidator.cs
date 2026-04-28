using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.Business.DTOs.Destino;

namespace Microservicio.atracciones.Business.Validators;

public static class DestinoValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearDestinoRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre del destino es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Pais))
            errors.Add("El país del destino es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarDestinoRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del destino es inválido.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre del destino es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Pais))
            errors.Add("El país del destino es obligatorio.");

        return errors;
    }
}