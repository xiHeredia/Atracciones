using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Idioma;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class IdiomaService : IIdiomaService
{
    private readonly IIdiomaDataService _idiomaDataService;

    public IdiomaService(IIdiomaDataService idiomaDataService)
    {
        _idiomaDataService = idiomaDataService;
    }

    public async Task<IdiomaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var idioma = await _idiomaDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (idioma is null)
            throw new NotFoundException("No se encontró el idioma.");

        return IdiomaBusinessMapper.ToResponse(idioma);
    }

    public async Task<IReadOnlyList<IdiomaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var idiomas = await _idiomaDataService.ListarAsync(cancellationToken);
        return idiomas.Select(IdiomaBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearIdiomaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = IdiomaValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = IdiomaBusinessMapper.ToDataModel(request);
        return await _idiomaDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarIdiomaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = IdiomaValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _idiomaDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el idioma.");

        var model = IdiomaBusinessMapper.ToDataModel(request);
        return await _idiomaDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _idiomaDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el idioma.");

        return true;
    }
}