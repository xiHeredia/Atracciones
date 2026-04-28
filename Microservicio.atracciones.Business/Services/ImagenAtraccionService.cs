using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ImagenAtraccion;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ImagenAtraccionService : IImagenAtraccionService
{
    private readonly IImagenAtraccionDataService _imagenAtraccionDataService;

    public ImagenAtraccionService(IImagenAtraccionDataService imagenAtraccionDataService)
    {
        _imagenAtraccionDataService = imagenAtraccionDataService;
    }

    public async Task<ImagenAtraccionResponse> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default)
    {
        var item = await _imagenAtraccionDataService.ObtenerAsync(atId, imgId, cancellationToken);

        if (item is null)
            throw new NotFoundException("No se encontró la relación imagen-atracción.");

        return ImagenAtraccionBusinessMapper.ToResponse(item);
    }

    public async Task<IReadOnlyList<ImagenAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var items = await _imagenAtraccionDataService.ListarPorAtraccionAsync(atId, cancellationToken);
        return items.Select(ImagenAtraccionBusinessMapper.ToResponse).ToList();
    }

    public async Task<bool> CrearAsync(CrearImagenAtraccionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ImagenAtraccionValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ImagenAtraccionBusinessMapper.ToDataModel(request);
        return await _imagenAtraccionDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int imgId, CancellationToken cancellationToken = default)
    {
        var ok = await _imagenAtraccionDataService.EliminarLogicoAsync(atId, imgId, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la relación imagen-atracción.");

        return true;
    }
}