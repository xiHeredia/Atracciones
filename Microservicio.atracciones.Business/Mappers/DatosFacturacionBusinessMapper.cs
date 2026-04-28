using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.DatosFacturacion;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class DatosFacturacionBusinessMapper
{
    public static DatosFacturacionDataModel ToDataModel(CrearDatosFacturacionRequest request)
    {
        return new DatosFacturacionDataModel
        {
            FacturaId = request.FacturaId,
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Correo = request.Correo,
            Telefono = request.Telefono
        };
    }

    public static DatosFacturacionDataModel ToDataModel(ActualizarDatosFacturacionRequest request)
    {
        return new DatosFacturacionDataModel
        {
            Id = request.Id,
            FacturaId = request.FacturaId,
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Correo = request.Correo,
            Telefono = request.Telefono
        };
    }

    public static DatosFacturacionResponse ToResponse(DatosFacturacionDataModel model)
    {
        return new DatosFacturacionResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            FacturaId = model.FacturaId,
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Correo = model.Correo,
            Telefono = model.Telefono
        };
    }
}