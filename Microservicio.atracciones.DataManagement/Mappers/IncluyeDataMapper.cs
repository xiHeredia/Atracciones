using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class IncluyeDataMapper
{
    public static IncluyeDataModel ToModel(IncluyeEntity entity)
    {
        return new IncluyeDataModel
        {
            Id = entity.IncId,
            Guid = entity.IncGuid,
            Descripcion = entity.IncDescripcion
        };
    }
}