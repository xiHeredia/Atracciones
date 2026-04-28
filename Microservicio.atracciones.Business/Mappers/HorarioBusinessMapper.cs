using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Horario;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class HorarioBusinessMapper
{
    public static HorarioDataModel ToDataModel(CrearHorarioRequest request)
    {
        return new HorarioDataModel
        {
            TicketId = request.TicketId,
            Fecha = request.Fecha,
            HoraInicio = request.HoraInicio,
            HoraFin = request.HoraFin,
            CuposDisponibles = request.CuposDisponibles
        };
    }

    public static HorarioDataModel ToDataModel(ActualizarHorarioRequest request)
    {
        return new HorarioDataModel
        {
            Id = request.Id,
            TicketId = request.TicketId,
            Fecha = request.Fecha,
            HoraInicio = request.HoraInicio,
            HoraFin = request.HoraFin,
            CuposDisponibles = request.CuposDisponibles
        };
    }

    public static HorarioResponse ToResponse(HorarioDataModel model)
    {
        return new HorarioResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            TicketId = model.TicketId,
            TicketTitulo = model.TicketTitulo,
            Fecha = model.Fecha,
            HoraInicio = model.HoraInicio,
            HoraFin = model.HoraFin,
            CuposDisponibles = model.CuposDisponibles
        };
    }
}