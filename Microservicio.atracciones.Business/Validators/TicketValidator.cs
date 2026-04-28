using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.Business.DTOs.Ticket;

namespace Microservicio.atracciones.Business.Validators;

public static class TicketValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearTicketRequest request)
    {
        var errors = new List<string>();

        if (request.AtraccionId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (string.IsNullOrWhiteSpace(request.Titulo))
            errors.Add("El título del ticket es obligatorio.");

        if (request.Precio < 0)
            errors.Add("El precio no puede ser negativo.");

        if (string.IsNullOrWhiteSpace(request.TipoParticipante))
            errors.Add("El tipo de participante es obligatorio.");

        if (request.CapacidadMaxima < 0)
            errors.Add("La capacidad máxima no puede ser negativa.");

        if (request.CuposDisponibles < 0)
            errors.Add("Los cupos disponibles no pueden ser negativos.");

        if (request.CuposDisponibles > request.CapacidadMaxima)
            errors.Add("Los cupos disponibles no pueden superar la capacidad máxima.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarTicketRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del ticket es inválido.");

        if (request.AtraccionId <= 0)
            errors.Add("El id de la atracción es inválido.");

        if (string.IsNullOrWhiteSpace(request.Titulo))
            errors.Add("El título del ticket es obligatorio.");

        if (request.Precio < 0)
            errors.Add("El precio no puede ser negativo.");

        if (string.IsNullOrWhiteSpace(request.TipoParticipante))
            errors.Add("El tipo de participante es obligatorio.");

        if (request.CapacidadMaxima < 0)
            errors.Add("La capacidad máxima no puede ser negativa.");

        if (request.CuposDisponibles < 0)
            errors.Add("Los cupos disponibles no pueden ser negativos.");

        if (request.CuposDisponibles > request.CapacidadMaxima)
            errors.Add("Los cupos disponibles no pueden superar la capacidad máxima.");

        return errors;
    }
}