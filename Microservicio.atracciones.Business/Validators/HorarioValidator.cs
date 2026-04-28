using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Horario;

namespace Microservicio.atracciones.Business.Validators;

public static class HorarioValidator
{
    public static IReadOnlyCollection<string> ValidarCreacion(CrearHorarioRequest request)
    {
        var errors = new List<string>();

        if (request.TicketId <= 0)
            errors.Add("El id del ticket es inválido.");

        if (request.HoraFin <= request.HoraInicio)
            errors.Add("La hora fin debe ser mayor a la hora inicio.");

        if (request.CuposDisponibles < 0)
            errors.Add("Los cupos disponibles no pueden ser negativos.");

        return errors;
    }

    public static IReadOnlyCollection<string> ValidarActualizacion(ActualizarHorarioRequest request)
    {
        var errors = new List<string>();

        if (request.Id <= 0)
            errors.Add("El id del horario es inválido.");

        if (request.TicketId <= 0)
            errors.Add("El id del ticket es inválido.");

        if (request.HoraFin <= request.HoraInicio)
            errors.Add("La hora fin debe ser mayor a la hora inicio.");

        if (request.CuposDisponibles < 0)
            errors.Add("Los cupos disponibles no pueden ser negativos.");

        return errors;
    }
}