using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class CategoriaDataMapper
{
    public static CategoriaDataModel ToModel(CategoriaEntity entity)
    {
        return new CategoriaDataModel
        {
            Id = entity.CatId,
            Guid = entity.CatGuid,
            ParentId = entity.CatParentId,
            Nombre = entity.CatNombre
        };
    }
}