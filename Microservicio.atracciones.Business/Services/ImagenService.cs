using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Imagen;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ImagenService : IImagenService
{
    private readonly IImagenDataService _imagenDataService;

    public ImagenService(IImagenDataService imagenDataService)
    {
        _imagenDataService = imagenDataService;
    }

    public async Task<ImagenResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var imagen = await _imagenDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (imagen is null)
            throw new NotFoundException("No se encontró la imagen.");

        return ImagenBusinessMapper.ToResponse(imagen);
    }

    public async Task<IReadOnlyList<ImagenResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var imagenes = await _imagenDataService.ListarAsync(cancellationToken);
        return imagenes.Select(ImagenBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearImagenRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ImagenValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ImagenBusinessMapper.ToDataModel(request);
        return await _imagenDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarImagenRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ImagenValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _imagenDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la imagen.");

        var model = ImagenBusinessMapper.ToDataModel(request);
        return await _imagenDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _imagenDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la imagen.");

        return true;
    }
}