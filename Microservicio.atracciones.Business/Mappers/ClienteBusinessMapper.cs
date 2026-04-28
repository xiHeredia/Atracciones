using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Cliente;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Mappers;

public static class ClienteBusinessMapper
{
    public static ClienteDataModel ToDataModel(CrearClienteRequest request)
    {
        return new ClienteDataModel
        {
            UsuarioId = request.UsuarioId,
            TipoIdentificacion = request.TipoIdentificacion,
            NumeroIdentificacion = request.NumeroIdentificacion,
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            RazonSocial = request.RazonSocial,
            Correo = request.Correo,
            Telefono = request.Telefono,
            Direccion = request.Direccion
        };
    }

    public static ClienteDataModel ToDataModel(ActualizarClienteRequest request)
    {
        return new ClienteDataModel
        {
            Id = request.Id,
            UsuarioId = request.UsuarioId,
            TipoIdentificacion = request.TipoIdentificacion,
            NumeroIdentificacion = request.NumeroIdentificacion,
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            RazonSocial = request.RazonSocial,
            Correo = request.Correo,
            Telefono = request.Telefono,
            Direccion = request.Direccion
        };
    }

    public static ClienteResponse ToResponse(ClienteDataModel model)
    {
        return new ClienteResponse
        {
            Id = model.Id,
            Guid = model.Guid,
            UsuarioId = model.UsuarioId,
            TipoIdentificacion = model.TipoIdentificacion,
            NumeroIdentificacion = model.NumeroIdentificacion,
            Nombres = model.Nombres,
            Apellidos = model.Apellidos,
            RazonSocial = model.RazonSocial,
            Correo = model.Correo,
            Telefono = model.Telefono,
            Direccion = model.Direccion
        };
    }
}