using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Mappers;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Services;

public class TicketDataService : ITicketDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TicketRepository.ObtenerPorIdAsync(id, cancellationToken);
        return entity is null ? null : TicketDataMapper.ToModel(entity);
    }

    public async Task<IReadOnlyList<TicketDataModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.TicketRepository.ListarAsync(cancellationToken);
        return entities.Select(TicketDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(TicketDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new TicketEntity
        {
            TckGuid = Guid.NewGuid(),
            AtId = model.AtraccionId,
            TckTitulo = model.Titulo,
            TckPrecio = model.Precio,
            TckTipoParticipante = model.TipoParticipante,
            TckCapacidadMaxima = model.CapacidadMaxima,
            TckCuposDisponibles = model.CuposDisponibles,
            TckFechaIngreso = DateTimeOffset.UtcNow,
            TckUsuarioIngreso = "api",
            TckIpIngreso = "127.0.0.1",
            TckEstado = "A"
        };

        await _unitOfWork.TicketRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.TckId;
    }

    public async Task<bool> ActualizarAsync(TicketDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TicketRepository.ObtenerParaActualizarAsync(model.Id, cancellationToken);

        if (entity is null)
            return false;

        entity.AtId = model.AtraccionId;
        entity.TckTitulo = model.Titulo;
        entity.TckPrecio = model.Precio;
        entity.TckTipoParticipante = model.TipoParticipante;
        entity.TckCapacidadMaxima = model.CapacidadMaxima;
        entity.TckCuposDisponibles = model.CuposDisponibles;
        entity.TckFechaMod = DateTimeOffset.UtcNow;
        entity.TckUsuarioMod = "api";
        entity.TckIpMod = "127.0.0.1";

        _unitOfWork.TicketRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TicketRepository.ObtenerParaActualizarAsync(id, cancellationToken);

        if (entity is null)
            return false;

        entity.TckEstado = "I";
        entity.TckFechaEliminacion = DateTimeOffset.UtcNow;
        entity.TckUsuarioEliminacion = "api";
        entity.TckIpEliminacion = "127.0.0.1";

        _unitOfWork.TicketRepository.Actualizar(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}