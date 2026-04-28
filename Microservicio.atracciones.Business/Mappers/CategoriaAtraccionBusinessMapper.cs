using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class CategoriaAtraccionBusinessMapper
{
    public static CategoriaAtraccionDataModel ToDataModel(CrearCategoriaAtraccionRequest request)
    {
        return new CategoriaAtraccionDataModel
        {
            AtId = request.AtId,
            CatId = request.CatId
        };
    }

    public static CategoriaAtraccionResponse ToResponse(CategoriaAtraccionDataModel model)
    {
        return new CategoriaAtraccionResponse
        {
            AtId = model.AtId,
            CatId = model.CatId,
            CategoriaNombre = model.CategoriaNombre
        };
    }
}