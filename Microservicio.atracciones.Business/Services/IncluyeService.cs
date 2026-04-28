using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Incluye;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class IncluyeService : IIncluyeService
{
    private readonly IIncluyeDataService _incluyeDataService;

    public IncluyeService(IIncluyeDataService incluyeDataService)
    {
        _incluyeDataService = incluyeDataService;
    }

    public async Task<IncluyeResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var incluye = await _incluyeDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (incluye is null)
            throw new NotFoundException("No se encontró el registro incluye.");

        return IncluyeBusinessMapper.ToResponse(incluye);
    }

    public async Task<IReadOnlyList<IncluyeResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var incluye = await _incluyeDataService.ListarAsync(cancellationToken);
        return incluye.Select(IncluyeBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearIncluyeRequest request, CancellationToken cancellationToken = default)
    {
        var errors = IncluyeValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = IncluyeBusinessMapper.ToDataModel(request);
        return await _incluyeDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarIncluyeRequest request, CancellationToken cancellationToken = default)
    {
        var errors = IncluyeValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _incluyeDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el registro incluye.");

        var model = IncluyeBusinessMapper.ToDataModel(request);
        return await _incluyeDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _incluyeDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el registro incluye.");

        return true;
    }
}