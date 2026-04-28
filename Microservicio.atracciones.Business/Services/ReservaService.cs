using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Reserva;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ReservaService : IReservaService
{
    private readonly IReservaDataService _reservaDataService;

    public ReservaService(IReservaDataService reservaDataService)
    {
        _reservaDataService = reservaDataService;
    }

    public async Task<ReservaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var reserva = await _reservaDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (reserva is null)
            throw new NotFoundException("No se encontró la reserva.");

        return ReservaBusinessMapper.ToResponse(reserva);
    }

    public async Task<IReadOnlyList<ReservaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var reservas = await _reservaDataService.ListarAsync(cancellationToken);
        return reservas.Select(ReservaBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearReservaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReservaValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ReservaBusinessMapper.ToDataModel(request);
        return await _reservaDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarReservaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReservaValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _reservaDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la reserva.");

        var model = ReservaBusinessMapper.ToDataModel(request);
        return await _reservaDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> CancelarAsync(int id, CancelarReservaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReservaValidator.ValidarCancelacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var ok = await _reservaDataService.CancelarAsync(id, request.Motivo, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la reserva.");

        return true;
    }
}