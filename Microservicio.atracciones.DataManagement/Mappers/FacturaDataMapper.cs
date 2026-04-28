using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class FacturaDataMapper
{
    public static FacturaDataModel ToModel(FacturaEntity entity)
    {
        return new FacturaDataModel
        {
            Id = entity.FacId,
            Guid = entity.FacGuid,
            ReservaId = entity.RevId,
            Numero = entity.FacNumero,
            FechaEmision = entity.FacFechaEmision,
            Total = entity.FacTotal,
            Observacion = entity.FacObservacion,
            OrigenCanal = entity.FacOrigenCanal,
            Estado = entity.FacEstado,
            MotivoInhabilitacion = entity.FacMotivoInhabilitacion
        };
    }
}