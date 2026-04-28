using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Categoria;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaDataService _categoriaDataService;

    public CategoriaService(ICategoriaDataService categoriaDataService)
    {
        _categoriaDataService = categoriaDataService;
    }

    public async Task<CategoriaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var categoria = await _categoriaDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (categoria is null)
            throw new NotFoundException("No se encontró la categoría.");

        return CategoriaBusinessMapper.ToResponse(categoria);
    }

    public async Task<IReadOnlyList<CategoriaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var categorias = await _categoriaDataService.ListarAsync(cancellationToken);
        return categorias.Select(CategoriaBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearCategoriaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = CategoriaValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = CategoriaBusinessMapper.ToDataModel(request);
        return await _categoriaDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarCategoriaRequest request, CancellationToken cancellationToken = default)
    {
        var errors = CategoriaValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _categoriaDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró la categoría.");

        var model = CategoriaBusinessMapper.ToDataModel(request);
        return await _categoriaDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _categoriaDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la categoría.");

        return true;
    }
}