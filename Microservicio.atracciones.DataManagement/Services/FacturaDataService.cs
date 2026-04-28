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

public class FacturaDataService : IFacturaDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public FacturaDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<FacturaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.FacturaRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : FacturaDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<FacturaDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.FacturaRepository.ListarAsync(cancellationToken);
        return entities.Select(FacturaDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(FacturaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new FacturaEntity
        {
            FacGuid = Guid.NewGuid(),
            RevId = model.ReservaId,
            FacNumero = string.IsNullOrWhiteSpace(model.Numero)
                ? $"FAC-{DateTime.UtcNow:yyyyMMddHHmmss}"
                : model.Numero,
            FacFechaEmision = DateTimeOffset.UtcNow,
            FacTotal = model.Total,
            FacObservacion = model.Observacion,
            FacOrigenCanal = model.OrigenCanal,
            FacUsuarioIngreso = "api",
            FacIpIngreso = "127.0.0.1",
            FacEstado = "A",
            FacRowVersion = 1
        };

        await _unitOfWork.FacturaRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.FacId;
    }

    public async Task<bool> ActualizarAsync(FacturaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.FacturaRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.RevId = model.ReservaId;
        entity.FacNumero = model.Numero;
        entity.FacTotal = model.Total;
        entity.FacObservacion = model.Observacion;
        entity.FacOrigenCanal = model.OrigenCanal;
        entity.FacFechaMod = DateTimeOffset.UtcNow;
        entity.FacUsuarioMod = "api";
        entity.FacIpMod = "127.0.0.1";
        entity.FacRowVersion += 1;

        _unitOfWork.FacturaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> InhabilitarAsync(int id, string motivo, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.FacturaRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.FacEstado = "I";
        entity.FacFechaEliminacion = DateTimeOffset.UtcNow;
        entity.FacUsuarioEliminacion = "api";
        entity.FacIpEliminacion = "127.0.0.1";
        entity.FacMotivoInhabilitacion = motivo;
        entity.FacRowVersion += 1;

        _unitOfWork.FacturaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}