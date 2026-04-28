using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Rol;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class RolService : IRolService
{
    private readonly IRolDataService _rolDataService;

    public RolService(IRolDataService rolDataService)
    {
        _rolDataService = rolDataService;
    }

    public async Task<RolResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var rol = await _rolDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (rol is null)
            throw new NotFoundException("No se encontró el rol.");

        return RolBusinessMapper.ToResponse(rol);
    }

    public async Task<IReadOnlyList<RolResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var roles = await _rolDataService.ListarAsync(cancellationToken);
        return roles.Select(RolBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearRolRequest request, CancellationToken cancellationToken = default)
    {
        var errors = RolValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = RolBusinessMapper.ToDataModel(request);
        return await _rolDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarRolRequest request, CancellationToken cancellationToken = default)
    {
        var errors = RolValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _rolDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el rol.");

        var model = RolBusinessMapper.ToDataModel(request);
        return await _rolDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _rolDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el rol.");

        return true;
    }
}