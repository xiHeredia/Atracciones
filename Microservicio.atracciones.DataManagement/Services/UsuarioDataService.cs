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

public class UsuarioDataService : IUsuarioDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : UsuarioDataMapper.ToModel(entity);
    }

    public async Task<UsuarioDataModel?> ObtenerPorLoginAsync(string login, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRepository.ObtenerPorLoginAsync(login, cancellationToken);
        return entity is null ? null : UsuarioDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<UsuarioDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.UsuarioRepository.ListarAsync(cancellationToken);
        return entities.Select(UsuarioDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(UsuarioDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new UsuarioEntity
        {
            UsuGuid = Guid.NewGuid(),
            UsuLogin = model.Login,
            UsuPasswordHash = model.PasswordHash,
            UsuFechaRegistro = DateTimeOffset.UtcNow,
            UsuUsuarioRegistro = "api",
            UsuIpRegistro = "127.0.0.1",
            UsuEstado = "A"
        };

        await _unitOfWork.UsuarioRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.UsuId;
    }

    public async Task<bool> ActualizarAsync(UsuarioDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.UsuLogin = model.Login;

        if (!string.IsNullOrWhiteSpace(model.PasswordHash))
            entity.UsuPasswordHash = model.PasswordHash;

        entity.UsuFechaMod = DateTimeOffset.UtcNow;
        entity.UsuUsuarioMod = "api";
        entity.UsuIpMod = "127.0.0.1";

        _unitOfWork.UsuarioRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.UsuEstado = "I";
        entity.UsuFechaEliminacion = DateTimeOffset.UtcNow;
        entity.UsuUsuarioEliminacion = "api";
        entity.UsuIpEliminacion = "127.0.0.1";

        _unitOfWork.UsuarioRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}