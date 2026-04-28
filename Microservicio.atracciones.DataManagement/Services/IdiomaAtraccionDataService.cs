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

public class IdiomaAtraccionDataService : IIdiomaAtraccionDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public IdiomaAtraccionDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<IdiomaAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.IdiomaAtraccionRepository.ListarPorAtraccionAsync(atId, cancellationToken);
        return entities.Select(IdiomaAtraccionDataMapper.ToModel).ToList();
    }

    public async Task<bool> CrearAsync(IdiomaAtraccionDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new IdiomaAtraccionEntity
        {
            AtId = model.AtId,
            IdId = model.IdId,
            IaFechaIngreso = DateTimeOffset.UtcNow,
            IaUsuarioIngreso = "api",
            IaEstado = "A"
        };

        await _unitOfWork.IdiomaAtraccionRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int idId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IdiomaAtraccionRepository.ObtenerAsync(atId, idId, cancellationToken);

        if (entity is null)
            return false;

        entity.IaEstado = "I";
        entity.IaFechaEliminacion = DateTimeOffset.UtcNow;
        entity.IaUsuarioEliminacion = "api";

        _unitOfWork.IdiomaAtraccionRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
    public async Task<IdiomaAtraccionDataModel?> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.IdiomaAtraccionRepository.ObtenerAsync(atId, idId, cancellationToken);
        return entity is null ? null : IdiomaAtraccionDataMapper.ToModel(entity);
    }
}