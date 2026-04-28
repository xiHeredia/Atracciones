using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.DatosFacturacion;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class DatosFacturacionService : IDatosFacturacionService
{
    private readonly IDatosFacturacionDataService _datosFacturacionDataService;

    public DatosFacturacionService(IDatosFacturacionDataService datosFacturacionDataService)
    {
        _datosFacturacionDataService = datosFacturacionDataService;
    }

    public async Task<DatosFacturacionResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var datos = await _datosFacturacionDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (datos is null)
            throw new NotFoundException("No se encontraron los datos de facturación.");

        return DatosFacturacionBusinessMapper.ToResponse(datos);
    }

    public async Task<IReadOnlyList<DatosFacturacionResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var datos = await _datosFacturacionDataService.ListarAsync(cancellationToken);
        return datos.Select(DatosFacturacionBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearDatosFacturacionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = DatosFacturacionValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = DatosFacturacionBusinessMapper.ToDataModel(request);
        return await _datosFacturacionDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarDatosFacturacionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = DatosFacturacionValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _datosFacturacionDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontraron los datos de facturación.");

        var model = DatosFacturacionBusinessMapper.ToDataModel(request);
        return await _datosFacturacionDataService.ActualizarAsync(model, cancellationToken);
    }
}