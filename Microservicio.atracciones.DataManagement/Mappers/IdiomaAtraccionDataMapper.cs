using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class IdiomaAtraccionDataMapper
{
    public static IdiomaAtraccionDataModel ToModel(IdiomaAtraccionEntity entity)
    {
        return new IdiomaAtraccionDataModel
        {
            AtId = entity.AtId,
            IdId = entity.IdId,
            IdiomaNombre = entity.Idioma?.IdiDescripcion
        };
    }
}