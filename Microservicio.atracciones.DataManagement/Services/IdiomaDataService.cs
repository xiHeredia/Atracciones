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

public class IdiomaDataService : IIdiomaDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public IdiomaDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IdiomaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IdiomaRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : IdiomaDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<IdiomaDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.IdiomaRepository.ListarAsync(cancellationToken);
        return entities.Select(IdiomaDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(IdiomaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new IdiomaEntity
        {
            IdiGuid = Guid.NewGuid(),
            IdiDescripcion = model.Nombre,
            IdiFechaIngreso = DateTimeOffset.UtcNow,
            IdUsuarioIngreso = "api",
            IdiIpIngreso = "127.0.0.1",
            IdiEstado = "A"
        };

        await _unitOfWork.IdiomaRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.IdiId;
    }

    public async Task<bool> ActualizarAsync(IdiomaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IdiomaRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.IdiDescripcion = model.Nombre;
        entity.IdiFechaMod = DateTimeOffset.UtcNow;
        entity.IdUsuarioMod = "api";
        entity.IdiIpMod = "127.0.0.1";

        _unitOfWork.IdiomaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IdiomaRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.IdiEstado = "I";
        entity.IdiFechaEliminacion = DateTimeOffset.UtcNow;
        entity.IdUsuarioEliminacion = "api";
        entity.IdiIpEliminacion = "127.0.0.1";

        _unitOfWork.IdiomaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}