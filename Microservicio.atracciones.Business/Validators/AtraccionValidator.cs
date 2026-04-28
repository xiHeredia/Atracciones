using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Atraccion;

namespace Microservicio.atracciones.Business.Validators;

public static class AtraccionValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearAtraccionRequest request)
    {
        var errors = new List<string>();

        if (request.DestinoId <= 0)
            errors.Add("El destino es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre de la atracción es obligatorio.");

        if (request.PrecioReferencia.HasValue && request.PrecioReferencia.Value < 0)
            errors.Add("El precio de referencia no puede ser negativo.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarAtraccionRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.DestinoId <= 0)
            errors.Add("El destino es obligatorio.");

        if (string.IsNullOrWhiteSpace(request.Nombre))
            errors.Add("El nombre de la atracción es obligatorio.");

        if (request.PrecioReferencia.HasValue && request.PrecioReferencia.Value < 0)
            errors.Add("El precio de referencia no puede ser negativo.");

        return errors;
    }
}