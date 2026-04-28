using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.UsuarioRol;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class UsuarioRolService : IUsuarioRolService
{
    private readonly IUsuarioRolDataService _usuarioRolDataService;

    public UsuarioRolService(IUsuarioRolDataService usuarioRolDataService)
    {
        _usuarioRolDataService = usuarioRolDataService;
    }

    public async Task<UsuarioRolResponse> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default)
    {
        var item = await _usuarioRolDataService.ObtenerAsync(usuarioId, rolId, cancellationToken);

        if (item is null)
            throw new NotFoundException("No se encontró la relación usuario-rol.");

        return UsuarioRolBusinessMapper.ToResponse(item);
    }

    public async Task<IReadOnlyList<UsuarioRolResponse>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default)
    {
        var items = await _usuarioRolDataService.ListarPorUsuarioAsync(usuarioId, cancellationToken);
        return items.Select(UsuarioRolBusinessMapper.ToResponse).ToList();
    }

    public async Task<bool> CrearAsync(CrearUsuarioRolRequest request, CancellationToken cancellationToken = default)
    {
        var errors = UsuarioRolValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = UsuarioRolBusinessMapper.ToDataModel(request);
        return await _usuarioRolDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default)
    {
        var ok = await _usuarioRolDataService.EliminarLogicoAsync(usuarioId, rolId, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró la relación usuario-rol.");

        return true;
    }
}