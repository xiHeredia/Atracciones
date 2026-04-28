using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Factura;

namespace Microservicio.atracciones.Business.Validators;

public static class FacturaValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearFacturaRequest request)
    {
        var errors = new List<string>();

        if (request.ReservaId <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (request.Total < 0)
            errors.Add("El total no puede ser negativo.");

        if (string.IsNullOrWhiteSpace(request.OrigenCanal))
            errors.Add("El origen del canal es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarFacturaRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id de la factura es inválido.");

        if (request.ReservaId <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (string.IsNullOrWhiteSpace(request.Numero))
            errors.Add("El número de factura es obligatorio.");

        if (request.Total < 0)
            errors.Add("El total no puede ser negativo.");

        if (string.IsNullOrWhiteSpace(request.OrigenCanal))
            errors.Add("El origen del canal es obligatorio.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarInhabilitacion(InhabilitarFacturaRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Motivo))
            errors.Add("El motivo de inhabilitación es obligatorio.");

        return errors;
    }
}