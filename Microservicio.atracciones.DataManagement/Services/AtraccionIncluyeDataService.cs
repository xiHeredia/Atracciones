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

public class AtraccionIncluyeDataService : IAtraccionIncluyeDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public AtraccionIncluyeDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AtraccionIncluyeDataModel?> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AtraccionIncluyeRepository.ObtenerAsync(atId, incId, cancellationToken);
        return entity is null ? null : AtraccionIncluyeDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<AtraccionIncluyeDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.AtraccionIncluyeRepository.ListarPorAtraccionAsync(atId, cancellationToken);
        return entities.Select(AtraccionIncluyeDataMapper.ToModel).ToList();
    }

    public async Task<bool> CrearAsync(AtraccionIncluyeDataModel model, CancellationToken cancellationToken = default)
    {
        var existente = await _unitOfWork.AtraccionIncluyeRepository.ObtenerAsync(model.AtId, model.IncId, cancellationToken);

        if (existente is not null)
            return true;

        var entity = new AtraccionIncluyeEntity
        {
            AtId = model.AtId,
            IncId = model.IncId,
            AiFechaIngreso = DateTimeOffset.UtcNow,
            AiUsuarioIngreso = "api",
            AiEstado = "A"
        };

        await _unitOfWork.AtraccionIncluyeRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int incId, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AtraccionIncluyeRepository.ObtenerAsync(atId, incId, cancellationToken);

        if (entity is null)
            return false;

        entity.AiEstado = "I";
        entity.AiFechaEliminacion = DateTimeOffset.UtcNow;
        entity.AiUsuarioEliminacion = "api";

        _unitOfWork.AtraccionIncluyeRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}