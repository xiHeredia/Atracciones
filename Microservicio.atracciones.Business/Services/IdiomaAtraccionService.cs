using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class IdiomaAtraccionService : IIdiomaAtraccionService
{
    private readonly IIdiomaAtraccionDataService _idiomaAtraccionDataService;

    public IdiomaAtraccionService(IIdiomaAtraccionDataService idiomaAtraccionDataService)
    {
        _idiomaAtraccionDataService = idiomaAtraccionDataService;
    }

    public async Task<IReadOnlyList<IdiomaAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        var items = await _idiomaAtraccionDataService.ListarPorAtraccionAsync(atId, cancellationToken);
        return items.Select(IdiomaAtraccionBusinessMapper.ToResponse).ToList();
    }

    public async Task<bool> CrearAsync(CrearIdiomaAtraccionRequest request, CancellationToken cancellationToken = default)
    {
        var errors = IdiomaAtraccionValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = IdiomaAtraccionBusinessMapper.ToDataModel(request);
        return await _idiomaAtraccionDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int atId, int idId, CancellationToken cancellationToken = default)
    {
        var ok = await _idiomaAtraccionDataService.EliminarLogicoAsync(atId, idId, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la relación idioma-atracción.");

        return true;
    }
    public async Task<IdiomaAtraccionResponse> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default)
    {
        var item = await _idiomaAtraccionDataService.ObtenerAsync(atId, idId, cancellationToken);

        if (item is null)
            throw new NotFoundException("No se encontró la relación idioma-atracción.");

        return IdiomaAtraccionBusinessMapper.ToResponse(item);
    }
}