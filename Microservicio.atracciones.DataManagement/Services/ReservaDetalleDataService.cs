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

public class ReservaDetalleDataService : IReservaDetalleDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReservaDetalleDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<ReservaDetalleDataModel>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.ReservaDetalleRepository.ListarPorReservaAsync(reservaId, cancellationToken);
        return entities.Select(ReservaDetalleDataMapper.ToModel).ToList();
    }

    public async Task<int> CrearAsync(ReservaDetalleDataModel model, CancellationToken cancellationToken = default)
    {
        var entity = new ReservaDetalleEntity
        {
            RdetGuid = Guid.NewGuid(),
            RevId = model.ReservaId,
            TckId = model.TicketId,
            RdetCantidad = model.Cantidad,
            RdetPrecioUnit = model.PrecioUnitario,
            RdetSubtotal = model.Subtotal,
            RdetFechaIngreso = DateTimeOffset.UtcNow,
            RdetUsuarioIngreso = "api",
            RdetIpIngreso = "127.0.0.1",
            RdetEstado = "A"
        };

        await _unitOfWork.ReservaDetalleRepository.AgregarAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.RdetId;
    }
}