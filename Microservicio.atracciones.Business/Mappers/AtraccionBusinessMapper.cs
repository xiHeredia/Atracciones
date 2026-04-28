using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Atraccion;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class AtraccionBusinessMapper
{
    public static AtraccionDataModel ToDataModel(CrearAtraccionRequest request)
    {
        return new AtraccionDataModel
        {
            DestinoId = request.DestinoId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.PrecioReferencia
        };
    }

    public static AtraccionDataModel ToDataModel(ActualizarAtraccionRequest request)
    {
        return new AtraccionDataModel
        {
            Id = request.Id,
            DestinoId = request.DestinoId,
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Precio = request.PrecioReferencia
        };
    }

    public static AtraccionResponse ToResponse(AtraccionDataModel model)
    {
        return new AtraccionResponse
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            PrecioReferencia = model.Precio,
            DestinoId = model.DestinoId,
            DestinoNombre = model.DestinoNombre
        };
    }
    public static AtraccionDetalleResponse ToDetalleResponse(AtraccionDetalleDataModel model)
    {
        return new AtraccionDetalleResponse
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            PrecioReferencia = model.PrecioReferencia,
            DestinoId = model.DestinoId,
            DestinoNombre = model.DestinoNombre,
            Idiomas = model.Idiomas,
            Incluye = model.Incluye,
            Imagenes = model.Imagenes
        };
    }
}