using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Categoria;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class CategoriaBusinessMapper
{
    public static CategoriaDataModel ToDataModel(CrearCategoriaRequest request)
    {
        return new CategoriaDataModel
        {
            ParentId = request.ParentId,
            Nombre = request.Nombre
        };
    }

    public static CategoriaDataModel ToDataModel(ActualizarCategoriaRequest request)
    {
        return new CategoriaDataModel
        {
            Id = request.Id,
            ParentId = request.ParentId,
            Nombre = request.Nombre
        };
    }

    public static CategoriaResponse ToResponse(CategoriaDataModel model)
    {
        return new CategoriaResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            ParentId = model.ParentId,
            Nombre = model.Nombre
        };
    }
}