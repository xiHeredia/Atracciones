using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Reserva;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ReservaBusinessMapper
{
    public static ReservaDataModel ToDataModel(CrearReservaRequest request)
    {
        return new ReservaDataModel
        {
            ClienteId = request.ClienteId,
            HorarioId = request.HorarioId,
            Subtotal = request.Subtotal,
            ValorIva = request.ValorIva,
            Total = request.Total,
            OrigenCanal = request.OrigenCanal
        };
    }

    public static ReservaDataModel ToDataModel(ActualizarReservaRequest request)
    {
        return new ReservaDataModel
        {
            Id = request.Id,
            ClienteId = request.ClienteId,
            HorarioId = request.HorarioId,
            Subtotal = request.Subtotal,
            ValorIva = request.ValorIva,
            Total = request.Total,
            OrigenCanal = request.OrigenCanal
        };
    }

    public static ReservaResponse ToResponse(ReservaDataModel model)
    {
        return new ReservaResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            Codigo = model.Codigo,
            ClienteId = model.ClienteId,
            HorarioId = model.HorarioId,
            FechaReservaUtc = model.FechaReservaUtc,
            Subtotal = model.Subtotal,
            ValorIva = model.ValorIva,
            Total = model.Total,
            OrigenCanal = model.OrigenCanal,
            Estado = model.Estado
        };
    }
}