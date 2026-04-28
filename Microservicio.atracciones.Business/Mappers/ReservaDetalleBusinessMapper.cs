using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaDetalle;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ReservaDetalleBusinessMapper
{
    public static ReservaDetalleDataModel ToDataModel(CrearReservaDetalleRequest request)
    {
        return new ReservaDetalleDataModel
        {
            ReservaId = request.ReservaId,
            TicketId = request.TicketId,
            Cantidad = request.Cantidad,
            PrecioUnitario = request.PrecioUnitario,
            Subtotal = request.Subtotal
        };
    }

    public static ReservaDetalleResponse ToResponse(ReservaDetalleDataModel model)
    {
        return new ReservaDetalleResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            ReservaId = model.ReservaId,
            TicketId = model.TicketId,
            Cantidad = model.Cantidad,
            PrecioUnitario = model.PrecioUnitario,
            Subtotal = model.Subtotal
        };
    }
}