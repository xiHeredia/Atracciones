using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.Business.DTOs.Factura;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class FacturaBusinessMapper
{
    public static FacturaDataModel ToDataModel(CrearFacturaRequest request)
    {
        return new FacturaDataModel
        {
            ReservaId = request.ReservaId,
            Numero = request.Numero ?? string.Empty,
            Total = request.Total,
            Observacion = request.Observacion,
            OrigenCanal = request.OrigenCanal
        };
    }

    public static FacturaDataModel ToDataModel(ActualizarFacturaRequest request)
    {
        return new FacturaDataModel
        {
            Id = request.Id,
            ReservaId = request.ReservaId,
            Numero = request.Numero,
            Total = request.Total,
            Observacion = request.Observacion,
            OrigenCanal = request.OrigenCanal
        };
    }

    public static FacturaResponse ToResponse(FacturaDataModel model)
    {
        return new FacturaResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            ReservaId = model.ReservaId,
            Numero = model.Numero,
            FechaEmision = model.FechaEmision,
            Total = model.Total,
            Observacion = model.Observacion,
            OrigenCanal = model.OrigenCanal,
            Estado = model.Estado,
            MotivoInhabilitacion = model.MotivoInhabilitacion
        };
    }
}