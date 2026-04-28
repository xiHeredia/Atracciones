using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ReservaDetalleDataMapper
{
    public static ReservaDetalleDataModel ToModel(ReservaDetalleEntity entity)
    {
        return new ReservaDetalleDataModel
        {
            Id = entity.RdetId,
            Guid = entity.RdetGuid,
            ReservaId = entity.RevId,
            TicketId = entity.TckId,
            Cantidad = entity.RdetCantidad,
            PrecioUnitario = entity.RdetPrecioUnit,
            Subtotal = entity.RdetSubtotal
        };
    }
}