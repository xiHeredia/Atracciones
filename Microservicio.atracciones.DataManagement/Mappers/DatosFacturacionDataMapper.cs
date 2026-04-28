using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class DatosFacturacionDataMapper
{
    public static DatosFacturacionDataModel ToModel(DatosFacturacionEntity entity)
    {
        return new DatosFacturacionDataModel
        {
            Id = entity.DfacId,
            Guid = entity.DfacGuid,
            FacturaId = entity.FacId,
            Nombre = entity.DfacNombre,
            Apellido = entity.DfacApellido,
            Correo = entity.DfacCorreo,
            Telefono = entity.DfacTelefono
        };
    }
}