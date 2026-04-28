using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Resenia;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ReseniaBusinessMapper
{
    public static ReseniaDataModel ToDataModel(CrearReseniaRequest request)
    {
        return new ReseniaDataModel
        {
            AtraccionId = request.AtraccionId,
            ReservaId = request.ReservaId,
            Comentario = request.Comentario,
            Rating = request.Rating
        };
    }

    public static ReseniaDataModel ToDataModel(ActualizarReseniaRequest request)
    {
        return new ReseniaDataModel
        {
            Id = request.Id,
            AtraccionId = request.AtraccionId,
            ReservaId = request.ReservaId,
            Comentario = request.Comentario,
            Rating = request.Rating
        };
    }

    public static ReseniaResponse ToResponse(ReseniaDataModel model)
    {
        return new ReseniaResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            AtraccionId = model.AtraccionId,
            ReservaId = model.ReservaId,
            Comentario = model.Comentario,
            Rating = model.Rating
        };
    }
}