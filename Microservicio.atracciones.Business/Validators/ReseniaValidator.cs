using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Resenia;

namespace Microservicio.atracciones.Business.Validators;

public static class ReseniaValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearReseniaRequest request)
    {
        var errors = new List<string>();

        if (request.AtraccionId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.ReservaId <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (string.IsNullOrWhiteSpace(request.Comentario))
            errors.Add("El comentario es obligatorio.");

        if (request.Rating < 1 || request.Rating > 5)
            errors.Add("El rating debe estar entre 1 y 5.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarReseniaRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la reseña es inválido.");

        if (request.AtraccionId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (request.ReservaId <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (string.IsNullOrWhiteSpace(request.Comentario))
            errors.Add("El comentario es obligatorio.");

        if (request.Rating < 1 || request.Rating > 5)
            errors.Add("El rating debe estar entre 1 y 5.");

        return errors;
    }
}