using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class DestinoDataMapper
{
    public static DestinoDataModel ToModel(DestinoEntity entity)
    {
        return new DestinoDataModel
        {
            Id = entity.DesId,
            Guid = entity.DesGuid,
            Nombre = entity.DesNombre,
            Pais = entity.DesPais,
            ImagenUrl = entity.DesImagenUrl
        };
    }
}