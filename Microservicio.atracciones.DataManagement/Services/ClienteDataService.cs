using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Mappers;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Services;

public class ClienteDataService : IClienteDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ClienteDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ClienteRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : ClienteDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<ClienteDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ClienteRepository.ListarAsync(cancellationToken);
        return entities.Select(ClienteDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(ClienteDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new ClienteEntity
        {
            CliGuid = Guid.NewGuid(),
            UsuId = model.UsuarioId,
            CliTipoIdentificacion = model.TipoIdentificacion,
            CliNumeroIdentificacion = model.NumeroIdentificacion,
            CliNombres = model.Nombres,
            CliApellidos = model.Apellidos,
            CliRazonSocial = model.RazonSocial,
            CliCorreo = model.Correo,
            CliTelefono = model.Telefono,
            CliDireccion = model.Direccion,
            CliFechaIngreso = DateTimeOffset.UtcNow,
            CliUsuarioIngreso = "api",
            CliIpIngreso = "127.0.0.1",
            CliEstado = "A",
            CliRowVersion = 1
        };

        await _unitOfWork.ClienteRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.CliId;
    }

    public async Task<bool> ActualizarAsync(ClienteDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ClienteRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.UsuId = model.UsuarioId;
        entity.CliTipoIdentificacion = model.TipoIdentificacion;
        entity.CliNumeroIdentificacion = model.NumeroIdentificacion;
        entity.CliNombres = model.Nombres;
        entity.CliApellidos = model.Apellidos;
        entity.CliRazonSocial = model.RazonSocial;
        entity.CliCorreo = model.Correo;
        entity.CliTelefono = model.Telefono;
        entity.CliDireccion = model.Direccion;
        entity.CliRowVersion += 1;

        _unitOfWork.ClienteRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ClienteRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.CliEstado = "I";
        entity.CliFechaEliminacion = DateTimeOffset.UtcNow;
        entity.CliUsuarioEliminacion = "api";
        entity.CliIpEliminacion = "127.0.0.1";
        entity.CliRowVersion += 1;

        _unitOfWork.ClienteRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}