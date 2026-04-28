using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Atraccion;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.Business.Services;

public class AtraccionService : IAtraccionService
{
    private readonly IAtraccionDataService _atraccionDataService;

    public AtraccionService(IAtraccionDataService atraccionDataService)
    {
        _atraccionDataService = atraccionDataService;
    }

    public async Task<AtraccionResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var atraccion = await _atraccionDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (atraccion is null)
            throw new NotFoundException("No se encontró la atracción solicitada.");

        return AtraccionBusinessMapper.ToResponse(atraccion);
    }

    public async Task<IReadOnlyList<AtraccionResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var atracciones = await _atraccionDataService.ListarAsync(cancellationToken);
        return atracciones.Select(AtraccionBusinessMapper.ToResponse).ToList();
    }

    public async Task<IReadOnlyList<AtraccionResponse>> BuscarAsync(AtraccionFiltroRequest request, CancellationToken cancellationToken = default)
    {
        var filtro = new AtraccionFiltroDataModel
        {
            Nombre = request.Nombre,
            DestinoId = request.DestinoId
        };

        var atracciones = await _atraccionDataService.BuscarAsync(filtro, cancellationToken);
        return atracciones.Select(AtraccionBusinessMapper.ToResponse).ToList();
    }
    public async Task<int> CrearAsync(CrearAtraccionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = AtraccionValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = AtraccionBusinessMapper.ToDataModel(request);

        return await _atraccionDataService.CrearAsync(model, cancellationToken);
    }
    public async Task<bool> ActualizarAsync(ActualizarAtraccionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = AtraccionValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _atraccionDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la atracción.");

        var model = AtraccionBusinessMapper.ToDataModel(request);

        return await _atraccionDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _atraccionDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la atracción.");

        return true;
    }
    public async Task<AtraccionDetalleResponse> ObtenerDetalleAsync(int id, CancellationToken cancellationToken = default)
    {
        var detalle = await _atraccionDataService.ObtenerDetalleAsync(id, cancellationToken);

        if (detalle is null)
            throw new NotFoundException("No se encontró la atracción.");

        return AtraccionBusinessMapper.ToDetalleResponse(detalle);
    }
}