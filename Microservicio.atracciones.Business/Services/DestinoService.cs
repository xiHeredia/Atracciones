using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Destino;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class DestinoService : IDestinoService
{
    private readonly IDestinoDataService _destinoDataService;

    public DestinoService(IDestinoDataService destinoDataService)
    {
        _destinoDataService = destinoDataService;
    }

    public async Task<DestinoResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var destino = await _destinoDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (destino is null)
            throw new NotFoundException("No se encontró el destino.");

        return DestinoBusinessMapper.ToResponse(destino);
    }

    public async Task<IReadOnlyList<DestinoResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var destinos = await _destinoDataService.ListarAsync(cancellationToken);
        return destinos.Select(DestinoBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearDestinoRequest request, CancellationToken cancellationToken = default)
    {
        var errors = DestinoValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = DestinoBusinessMapper.ToDataModel(request);
        return await _destinoDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarDestinoRequest request, CancellationToken cancellationToken = default)
    {
        var errors = DestinoValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _destinoDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el destino.");

        var model = DestinoBusinessMapper.ToDataModel(request);
        return await _destinoDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _destinoDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el destino.");

        return true;
    }
}