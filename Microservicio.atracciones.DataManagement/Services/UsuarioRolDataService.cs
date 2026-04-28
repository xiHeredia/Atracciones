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

public class UsuarioRolDataService : IUsuarioRolDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioRolDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UsuarioRolDataModel?> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRolRepository.ObtenerAsync(usuarioId, rolId, cancellationToken);
        return entity is null ? null : UsuarioRolDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<UsuarioRolDataModel>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.UsuarioRolRepository.ListarPorUsuarioAsync(usuarioId, cancellationToken);
        return entities.Select(UsuarioRolDataMapper.ToModel).ToList();
    }

    public async Task<bool> CrearAsync(UsuarioRolDataModel model, CancellationToken cancellationToken = default)
    {
        var existente = await _unitOfWork.UsuarioRolRepository.ObtenerAsync(model.UsuarioId, model.RolId, cancellationToken);

        if (existente is not null)
            return true;

        var entity = new UsuarioRolEntity
        {
            UsuId = model.UsuarioId,
            RolId = model.RolId,
            UsuRolEstado = "A"
        };

        await _unitOfWork.UsuarioRolRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.UsuarioRolRepository.ObtenerAsync(usuarioId, rolId, cancellationToken);

        if (entity is null)
            return false;

        entity.UsuRolEstado = "I";

        _unitOfWork.UsuarioRolRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}