using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class RolDataMapper
{
    public static RolDataModel ToModel(RolEntity entity)
    {
        return new RolDataModel
        {
            Id = entity.RolId,
            Guid = entity.RolGuid,
            Descripcion = entity.RolDescripcion
        };
    }
}