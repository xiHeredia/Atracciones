using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Cliente;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteDataService _clienteDataService;

    public ClienteService(IClienteDataService clienteDataService)
    {
        _clienteDataService = clienteDataService;
    }

    public async Task<ClienteResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _clienteDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (cliente is null)
            throw new NotFoundException("No se encontró el cliente.");

        return ClienteBusinessMapper.ToResponse(cliente);
    }

    public async Task<ClienteResponse?> ObtenerPorUsuarioIdAsync(int usuarioId, CancellationToken cancellationToken = default)
    {
        var cliente = await _clienteDataService.ObtenerPorUsuarioIdAsync(usuarioId, cancellationToken);
        return cliente is null ? null : ClienteBusinessMapper.ToResponse(cliente);
    }

    public async Task<IReadOnlyList<ClienteResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await _clienteDataService.ListarAsync(cancellationToken);
        return clientes.Select(ClienteBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearClienteRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ClienteValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ClienteBusinessMapper.ToDataModel(request);
        return await _clienteDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarClienteRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ClienteValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _clienteDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el cliente.");

        var model = ClienteBusinessMapper.ToDataModel(request);
        return await _clienteDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _clienteDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el cliente.");

        return true;
    }
}
