using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Usuario;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioDataService _usuarioDataService;

    public UsuarioService(IUsuarioDataService usuarioDataService)
    {
        _usuarioDataService = usuarioDataService;
    }

    public async Task<UsuarioResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var usuario = await _usuarioDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (usuario is null)
            throw new NotFoundException("No se encontró el usuario.");

        return UsuarioBusinessMapper.ToResponse(usuario);
    }

    public async Task<IReadOnlyList<UsuarioResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var usuarios = await _usuarioDataService.ListarAsync(cancellationToken);
        return usuarios.Select(UsuarioBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearUsuarioRequest request, CancellationToken cancellationToken = default)
    {
        var errors = UsuarioValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _usuarioDataService.ObtenerPorLoginAsync(request.Login, cancellationToken);

        if (existente is not null)
            throw new ValidationException("Error de validación", new[] { "Ya existe un usuario con ese login." });

        var model = UsuarioBusinessMapper.ToDataModel(request);
        return await _usuarioDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarUsuarioRequest request, CancellationToken cancellationToken = default)
    {
        var errors = UsuarioValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _usuarioDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el usuario.");

        var usuarioConLogin = await _usuarioDataService.ObtenerPorLoginAsync(request.Login, cancellationToken);

        if (usuarioConLogin is not null && usuarioConLogin.Id != request.Id)
            throw new ValidationException("Error de validación", new[] { "Ya existe otro usuario con ese login." });

        var model = UsuarioBusinessMapper.ToDataModel(request);
        return await _usuarioDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _usuarioDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el usuario.");

        return true;
    }
}