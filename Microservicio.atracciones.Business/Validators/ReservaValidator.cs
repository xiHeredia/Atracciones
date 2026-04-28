using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Reserva;

namespace Microservicio.atracciones.Business.Validators;

public static class ReservaValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearReservaRequest request)
    {
        var errors = new List<string>();

        if (request.ClienteId <= 0)
            errors.Add("El id del cliente es inválido.");

        if (request.HorarioId <= 0)
            errors.Add("El id del horario es inválido.");

        if (request.Subtotal < 0)
            errors.Add("El subtotal no puede ser negativo.");

        if (request.ValorIva < 0)
            errors.Add("El valor de IVA no puede ser negativo.");

        if (request.Total < 0)
            errors.Add("El total no puede ser negativo.");

        if (request.Total != request.Subtotal + request.ValorIva)
            errors.Add("El total debe ser igual al subtotal más el IVA.");

        if (string.IsNullOrWhiteSpace(request.OrigenCanal))
            errors.Add("El origen del canal es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarReservaRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (request.ClienteId <= 0)
            errors.Add("El id del cliente es inválido.");

        if (request.HorarioId <= 0)
            errors.Add("El id del horario es inválido.");

        if (request.Subtotal < 0)
            errors.Add("El subtotal no puede ser negativo.");

        if (request.ValorIva < 0)
            errors.Add("El valor de IVA no puede ser negativo.");

        if (request.Total < 0)
            errors.Add("El total no puede ser negativo.");

        if (request.Total != request.Subtotal + request.ValorIva)
            errors.Add("El total debe ser igual al subtotal más el IVA.");

        if (string.IsNullOrWhiteSpace(request.OrigenCanal))
            errors.Add("El origen del canal es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarCancelacion(CancelarReservaRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Motivo))
            errors.Add("El motivo de cancelación es obligatorio.");

        return errors;
    }
}