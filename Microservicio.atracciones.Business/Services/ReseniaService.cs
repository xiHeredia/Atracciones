using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Resenia;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ReseniaService : IReseniaService
{
    private readonly IReseniaDataService _reseniaDataService;

    public ReseniaService(IReseniaDataService reseniaDataService)
    {
        _reseniaDataService = reseniaDataService;
    }

    public async Task<ReseniaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var resenia = await _reseniaDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (resenia is null)
            throw new NotFoundException("No se encontró la reseña.");

        return ReseniaBusinessMapper.ToResponse(resenia);
    }

    public async Task<IReadOnlyList<ReseniaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var resenias = await _reseniaDataService.ListarAsync(cancellationToken);
        return resenias.Select(ReseniaBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearReseniaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReseniaValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ReseniaBusinessMapper.ToDataModel(request);
        return await _reseniaDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarReseniaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReseniaValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _reseniaDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la reseña.");

        var model = ReseniaBusinessMapper.ToDataModel(request);
        return await _reseniaDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _reseniaDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la reseña.");

        return true;
    }
}