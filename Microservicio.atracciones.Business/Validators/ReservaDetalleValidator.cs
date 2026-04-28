using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaDetalle;

namespace Microservicio.atracciones.Business.Validators;

public static class ReservaDetalleValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearReservaDetalleRequest request)
    {
        var errors = new List<string>();

        if (request.ReservaId <= 0)
            errors.Add("El id de la reserva es inválido.");

        if (request.TicketId <= 0)
            errors.Add("El id del ticket es inválido.");

        if (request.Cantidad <= 0)
            errors.Add("La cantidad debe ser mayor a cero.");

        if (request.PrecioUnitario < 0)
            errors.Add("El precio unitario no puede ser negativo.");

        if (request.Subtotal != request.Cantidad * request.PrecioUnitario)
            errors.Add("El subtotal debe ser igual a cantidad por precio unitario.");

        return errors;
    }
}