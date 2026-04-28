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

public class HorarioDataService : IHorarioDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public HorarioDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<HorarioDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.HorarioRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : HorarioDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<HorarioDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.HorarioRepository.ListarAsync(cancellationToken);
        return entities.Select(HorarioDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(HorarioDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new HorarioEntity
        {
            HorGuid = Guid.NewGuid(),
            TckId = model.TicketId,
            HorFecha = model.Fecha,
            HorHoraInicio = model.HoraInicio,
            HorHoraFin = model.HoraFin,
            HorCuposDisponibles = model.CuposDisponibles,
            HorFechaIngreso = DateTimeOffset.UtcNow,
            HorUsuarioIngreso = "api",
            HorIpIngreso = "127.0.0.1",
            HorEstado = "A"
        };

        await _unitOfWork.HorarioRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.HorId;
    }

    public async Task<bool> ActualizarAsync(HorarioDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.HorarioRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.TckId = model.TicketId;
        entity.HorFecha = model.Fecha;
        entity.HorHoraInicio = model.HoraInicio;
        entity.HorHoraFin = model.HoraFin;
        entity.HorCuposDisponibles = model.CuposDisponibles;
        entity.HorFechaMod = DateTimeOffset.UtcNow;
        entity.HorUsuarioMod = "api";
        entity.HorIpMod = "127.0.0.1";

        _unitOfWork.HorarioRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.HorarioRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.HorEstado = "I";
        entity.HorFechaEliminacion = DateTimeOffset.UtcNow;
        entity.HorUsuarioEliminacion = "api";
        entity.HorIpEliminacion = "127.0.0.1";

        _unitOfWork.HorarioRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}