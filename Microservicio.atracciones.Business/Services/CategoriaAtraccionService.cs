using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class CategoriaAtraccionService : ICategoriaAtraccionService
{
    private readonly ICategoriaAtraccionDataService _categoriaAtraccionDataService;

    public CategoriaAtraccionService(ICategoriaAtraccionDataService categoriaAtraccionDataService)
    {
        _categoriaAtraccionDataService = categoriaAtraccionDataService;
    }

    public async Task<CategoriaAtraccionResponse> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default)
    {
        var item = await _categoriaAtraccionDataService.ObtenerAsync(atId, catId, cancellationToken);

        if (item is null)
            throw new NotFoundException("No se encontró la relación categoría-atracción.");

        return CategoriaAtraccionBusinessMapper.ToResponse(item);
    }

    public async Task<IReadOnlyList<CategoriaAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var items = await _categoriaAtraccionDataService.ListarPorAtraccionAsync(atId, cancellationToken);
        return items.Select(CategoriaAtraccionBusinessMapper.ToResponse).ToList();
    }

    public async Task<bool> CrearAsync(CrearCategoriaAtraccionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = CategoriaAtraccionValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = CategoriaAtraccionBusinessMapper.ToDataModel(request);
        return await _categoriaAtraccionDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int catId, CancellationToken cancellationToken = default)
    {
        var ok = await _categoriaAtraccionDataService.EliminarLogicoAsync(atId, catId, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la relación categoría-atracción.");

        return true;
    }
}