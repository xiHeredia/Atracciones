using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ReservaDataMapper
{
    public static ReservaDataModel ToModel(ReservaEntity entity)
    {
        return new ReservaDataModel
        {
            Id = entity.RevId,
            Guid = entity.RevGuid,
            Codigo = entity.RevCodigo,
            ClienteId = entity.CliId,
            HorarioId = entity.HorId,
            FechaReservaUtc = entity.RevFechaReservaUtc,
            Subtotal = entity.RevSubtotal,
            ValorIva = entity.RevValorIva,
            Total = entity.RevTotal,
            OrigenCanal = entity.RevOrigenCanal,
            Estado = entity.RevEstado
        };
    }
}