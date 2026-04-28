using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Mappers;

public static class ClienteDataMapper
{
    public static ClienteDataModel ToModel(ClienteEntity entity)
    {
        return new ClienteDataModel
        {
            Id = entity.CliId,
            Guid = entity.CliGuid,
            UsuarioId = entity.UsuId,
            TipoIdentificacion = entity.CliTipoIdentificacion,
            NumeroIdentificacion = entity.CliNumeroIdentificacion,
            Nombres = entity.CliNombres,
            Apellidos = entity.CliApellidos,
            RazonSocial = entity.CliRazonSocial,
            Correo = entity.CliCorreo,
            Telefono = entity.CliTelefono,
            Direccion = entity.CliDireccion
        };
    }
}