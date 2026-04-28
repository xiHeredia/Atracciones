using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Ticket;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class TicketService : ITicketService
{
    private readonly ITicketDataService _ticketDataService;

    public TicketService(ITicketDataService ticketDataService)
    {
        _ticketDataService = ticketDataService;
    }

    public async Task<TicketResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (ticket is null)
            throw new NotFoundException("No se encontró el ticket.");

        return TicketBusinessMapper.ToResponse(ticket);
    }

    public async Task<IReadOnlyList<TicketResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var tickets = await _ticketDataService.ListarAsync(cancellationToken);
        return tickets.Select(TicketBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearTicketRequest request, CancellationToken cancellationToken = default)
    {
        var errors = TicketValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = TicketBusinessMapper.ToDataModel(request);
        return await _ticketDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarTicketRequest request, CancellationToken cancellationToken = default)
    {
        var errors = TicketValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _ticketDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el ticket.");

        var model = TicketBusinessMapper.ToDataModel(request);
        return await _ticketDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _ticketDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el ticket.");

        return true;
    }
}