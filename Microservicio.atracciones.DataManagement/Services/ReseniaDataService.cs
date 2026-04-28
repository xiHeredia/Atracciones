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

public class ReseniaDataService : IReseniaDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReseniaDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReseniaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReseniaRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : ReseniaDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<ReseniaDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ReseniaRepository.ListarAsync(cancellationToken);
        return entities.Select(ReseniaDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(ReseniaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new ReseniaEntity
        {
            RsnGuid = Guid.NewGuid(),
            AtId = model.AtraccionId,
            RevId = model.ReservaId,
            RsnComentario = model.Comentario,
            RsnRating = model.Rating,
            RsnFechaCreacion = DateTimeOffset.UtcNow,
            RsnUsuarioCreacion = "api",
            RsnIpCreacion = "127.0.0.1",
            RsnEstado = "A"
        };

        await _unitOfWork.ReseniaRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.RsnId;
    }

    public async Task<bool> ActualizarAsync(ReseniaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReseniaRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.AtId = model.AtraccionId;
        entity.RevId = model.ReservaId;
        entity.RsnComentario = model.Comentario;
        entity.RsnRating = model.Rating;
        entity.RsnFechaMod = DateTimeOffset.UtcNow;
        entity.RsnUsuarioMod = "api";
        entity.RsnIpMod = "127.0.0.1";

        _unitOfWork.ReseniaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReseniaRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.RsnEstado = "I";
        entity.RsnFechaEliminacion = DateTimeOffset.UtcNow;
        entity.RsnUsuarioEliminacion = "api";
        entity.RsnIpEliminacion = "127.0.0.1";

        _unitOfWork.ReseniaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}