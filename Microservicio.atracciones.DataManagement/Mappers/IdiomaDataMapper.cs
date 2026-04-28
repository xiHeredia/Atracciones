using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class IdiomaDataMapper
{
    public static IdiomaDataModel ToModel(IdiomaEntity entity)
    {
        return new IdiomaDataModel
        {
            Id = entity.IdiId,
            Guid = entity.IdiGuid,
            Nombre = entity.IdiDescripcion
        };
    }
}