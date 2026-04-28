using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Factura;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class FacturaService : IFacturaService
{
    private readonly IFacturaDataService _facturaDataService;

    public FacturaService(IFacturaDataService facturaDataService)
    {
        _facturaDataService = facturaDataService;
    }

    public async Task<FacturaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var factura = await _facturaDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (factura is null)
            throw new NotFoundException("No se encontró la factura.");

        return FacturaBusinessMapper.ToResponse(factura);
    }

    public async Task<IReadOnlyList<FacturaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var facturas = await _facturaDataService.ListarAsync(cancellationToken);
        return facturas.Select(FacturaBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearFacturaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = FacturaValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = FacturaBusinessMapper.ToDataModel(request);
        return await _facturaDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarFacturaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = FacturaValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _facturaDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la factura.");

        var model = FacturaBusinessMapper.ToDataModel(request);
        return await _facturaDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> InhabilitarAsync(int id, InhabilitarFacturaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = FacturaValidator.ValidarInhabilitacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var ok = await _facturaDataService.InhabilitarAsync(id, request.Motivo, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la factura.");

        return true;
    }
}