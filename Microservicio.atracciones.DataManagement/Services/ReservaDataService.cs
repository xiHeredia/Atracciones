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

public class ReservaDataService : IReservaDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReservaDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReservaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReservaRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : ReservaDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<ReservaDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ReservaRepository.ListarAsync(cancellationToken);
        return entities.Select(ReservaDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(ReservaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new ReservaEntity
        {
            RevGuid = Guid.NewGuid(),
            RevCodigo = string.IsNullOrWhiteSpace(model.Codigo)
                ? $"REV-{DateTime.UtcNow:yyyyMMddHHmmss}"
                : model.Codigo,
            CliId = model.ClienteId,
            HorId = model.HorarioId,
            RevFechaReservaUtc = DateTimeOffset.UtcNow,
            RevSubtotal = model.Subtotal,
            RevValorIva = model.ValorIva,
            RevTotal = model.Total,
            RevOrigenCanal = model.OrigenCanal,
            RevUsuarioIngreso = "api",
            RevIpIngreso = "127.0.0.1",
            RevEstado = "A"
        };

        await _unitOfWork.ReservaRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.RevId;
    }

    public async Task<bool> ActualizarAsync(ReservaDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReservaRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.CliId = model.ClienteId;
        entity.HorId = model.HorarioId;
        entity.RevSubtotal = model.Subtotal;
        entity.RevValorIva = model.ValorIva;
        entity.RevTotal = model.Total;
        entity.RevOrigenCanal = model.OrigenCanal;
        entity.RevFechaMod = DateTimeOffset.UtcNow;
        entity.RevUsuarioMod = "api";
        entity.RevIpMod = "127.0.0.1";

        _unitOfWork.ReservaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> CancelarAsync(int id, string motivo, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.ReservaRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.RevEstado = "C";
        entity.RevFechaCancelacion = DateTimeOffset.UtcNow;
        entity.RevUsuarioCancelacion = "api";
        entity.RevIpCancelacion = "127.0.0.1";
        entity.RevMotivoCancelacion = motivo;

        _unitOfWork.ReservaRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}