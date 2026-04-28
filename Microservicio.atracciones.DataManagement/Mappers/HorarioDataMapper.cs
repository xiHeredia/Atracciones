using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class HorarioDataMapper
{
    public static HorarioDataModel ToModel(HorarioEntity entity)
    {
        return new HorarioDataModel
        {
            Id = entity.HorId,
            Guid = entity.HorGuid,
            TicketId = entity.TckId,
            TicketTitulo = entity.Ticket?.TckTitulo,
            Fecha = entity.HorFecha,
            HoraInicio = entity.HorHoraInicio,
            HoraFin = entity.HorHoraFin,
            CuposDisponibles = entity.HorCuposDisponibles
        };
    }
}