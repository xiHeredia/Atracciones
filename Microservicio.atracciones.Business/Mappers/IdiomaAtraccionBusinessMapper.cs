using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class IdiomaAtraccionBusinessMapper
{
    public static IdiomaAtraccionDataModel ToDataModel(CrearIdiomaAtraccionRequest request)
    {
        return new IdiomaAtraccionDataModel
        {
            AtId = request.AtId,
            IdId = request.IdId
        };
    }

    public static IdiomaAtraccionResponse ToResponse(IdiomaAtraccionDataModel model)
    {
        return new IdiomaAtraccionResponse
        {
            AtId = model.AtId,
            IdId = model.IdId,
            IdiomaNombre = model.IdiomaNombre
        };
    }
}