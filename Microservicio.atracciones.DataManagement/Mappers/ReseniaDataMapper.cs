using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ReseniaDataMapper
{
    public static ReseniaDataModel ToModel(ReseniaEntity entity)
    {
        return new ReseniaDataModel
        {
            Id = entity.RsnId,
            Guid = entity.RsnGuid,
            AtraccionId = entity.AtId,
            ReservaId = entity.RevId,
            Comentario = entity.RsnComentario,
            Rating = entity.RsnRating
        };
    }
}