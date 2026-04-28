using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class AtraccionIncluyeDataMapper
{
    public static AtraccionIncluyeDataModel ToModel(AtraccionIncluyeEntity entity)
    {
        return new AtraccionIncluyeDataModel
        {
            AtId = entity.AtId,
            IncId = entity.IncId,
            IncluyeDescripcion = entity.Incluye?.IncDescripcion
        };
    }
}