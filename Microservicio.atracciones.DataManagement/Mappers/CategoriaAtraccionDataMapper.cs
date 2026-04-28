using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class CategoriaAtraccionDataMapper
{
    public static CategoriaAtraccionDataModel ToModel(CategoriaAtraccionEntity entity)
    {
        return new CategoriaAtraccionDataModel
        {
            AtId = entity.AtId,
            CatId = entity.CatId,
            CategoriaNombre = entity.Categoria?.CatNombre
        };
    }
}