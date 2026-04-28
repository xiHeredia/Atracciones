using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.AtraccionIncluye;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class AtraccionIncluyeService : IAtraccionIncluyeService
{
    private readonly IAtraccionIncluyeDataService _atraccionIncluyeDataService;

    public AtraccionIncluyeService(IAtraccionIncluyeDataService atraccionIncluyeDataService)
    {
        _atraccionIncluyeDataService = atraccionIncluyeDataService;
    }

    public async Task<AtraccionIncluyeResponse> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default)
    {
        var item = await _atraccionIncluyeDataService.ObtenerAsync(atId, incId, cancellationToken);

        if (item is null)
            throw new NotFoundException("No se encontró la relación atracción-incluye.");

        return AtraccionIncluyeBusinessMapper.ToResponse(item);
    }

    public async Task<IReadOnlyList<AtraccionIncluyeResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var items = await _atraccionIncluyeDataService.ListarPorAtraccionAsync(atId, cancellationToken);
        return items.Select(AtraccionIncluyeBusinessMapper.ToResponse).ToList();
    }

    public async Task<bool> CrearAsync(CrearAtraccionIncluyeRequest request, CancellationToken cancellationToken = default)
    {
        var errors = AtraccionIncluyeValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = AtraccionIncluyeBusinessMapper.ToDataModel(request);
        return await _atraccionIncluyeDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int incId, CancellationToken cancellationToken = default)
    {
        var ok = await _atraccionIncluyeDataService.EliminarLogicoAsync(atId, incId, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la relación atracción-incluye.");

        return true;
    }
}