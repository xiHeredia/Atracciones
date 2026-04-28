using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaCompleta;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Services;

public class ReservaCompletaService : IReservaCompletaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReservaDataService _reservaDataService;
    private readonly IReservaDetalleDataService _reservaDetalleDataService;

    private const decimal IVA = 0.15m;

    public ReservaCompletaService(
        IUnitOfWork unitOfWork,
        IReservaDataService reservaDataService,
        IReservaDetalleDataService reservaDetalleDataService)
    {
        _unitOfWork = unitOfWork;
        _reservaDataService = reservaDataService;
        _reservaDetalleDataService = reservaDetalleDataService;
    }

    public async Task<ReservaCompletaResponse> CrearAsync(CrearReservaCompletaRequest request, CancellationToken cancellationToken = default)
    {
        if (request.ClienteId <= 0)
            throw new ValidationException("Error de validación", new[] { "El cliente es obligatorio." });

        if (request.HorarioId <= 0)
            throw new ValidationException("Error de validación", new[] { "El horario es obligatorio." });

        if (request.Items is null || !request.Items.Any())
            throw new ValidationException("Error de validación", new[] { "Debe ingresar al menos un detalle." });

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var horario = await _unitOfWork.HorarioRepository.ObtenerParaActualizarAsync(request.HorarioId, cancellationToken);

            if (horario is null)
                throw new NotFoundException("No se encontró el horario.");

            var cantidadTotal = request.Items.Sum(x => x.Cantidad);

            if (cantidadTotal <= 0)
                throw new ValidationException("Error de validación", new[] { "La cantidad total debe ser mayor a cero." });

            if (horario.HorCuposDisponibles < cantidadTotal)
                throw new ValidationException("Error de validación", new[] { "No existen cupos suficientes para este horario." });

            decimal subtotal = 0;

            var detalleCalculado = new List<(int TicketId, int Cantidad, decimal PrecioUnitario, decimal Subtotal)>();

            foreach (var item in request.Items)
            {
                if (item.TicketId <= 0)
                    throw new ValidationException("Error de validación", new[] { "El ticket es obligatorio." });

                if (item.Cantidad <= 0)
                    throw new ValidationException("Error de validación", new[] { "La cantidad debe ser mayor a cero." });

                var ticket = await _unitOfWork.TicketRepository.ObtenerPorIdAsync(item.TicketId, cancellationToken);

                if (ticket is null)
                    throw new NotFoundException($"No se encontró el ticket {item.TicketId}.");

                var itemSubtotal = ticket.TckPrecio * item.Cantidad;
                subtotal += itemSubtotal;

                detalleCalculado.Add((item.TicketId, item.Cantidad, ticket.TckPrecio, itemSubtotal));
            }

            var valorIva = Math.Round(subtotal * IVA, 2);
            var total = subtotal + valorIva;

            var reservaId = await _reservaDataService.CrearAsync(new ReservaDataModel
            {
                ClienteId = request.ClienteId,
                HorarioId = request.HorarioId,
                Subtotal = subtotal,
                ValorIva = valorIva,
                Total = total,
                OrigenCanal = request.OrigenCanal
            }, cancellationToken);

            foreach (var item in detalleCalculado)
            {
                await _reservaDetalleDataService.CrearAsync(new ReservaDetalleDataModel
                {
                    ReservaId = reservaId,
                    TicketId = item.TicketId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = item.Subtotal
                }, cancellationToken);
            }

            horario.HorCuposDisponibles -= cantidadTotal;
            _unitOfWork.HorarioRepository.Actualizar(horario);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            var reserva = await _reservaDataService.ObtenerPorIdAsync(reservaId, cancellationToken);

            return new ReservaCompletaResponse
            {
                ReservaId = reservaId,
                Codigo = reserva?.Codigo ?? string.Empty,
                Subtotal = subtotal,
                ValorIva = valorIva,
                Total = total
            };
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}