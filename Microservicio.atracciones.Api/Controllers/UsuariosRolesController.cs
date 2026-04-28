using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.UsuarioRol;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/usuarios-roles")]
[Authorize]
public class UsuariosRolesController : ControllerBase
{
    private readonly IUsuarioRolService _usuarioRolService;

    public UsuariosRolesController(IUsuarioRolService usuarioRolService)
    {
        _usuarioRolService = usuarioRolService;
    }

    [HttpGet("usuario/{usuarioId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<UsuarioRolResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorUsuario(int usuarioId, CancellationToken cancellationToken)
    {
        var result = await _usuarioRolService.ListarPorUsuarioAsync(usuarioId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<UsuarioRolResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{usuarioId:int}/{rolId:int}")]
    [ProducesResponseType(typeof(ApiResponse<UsuarioRolResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obtener(int usuarioId, int rolId, CancellationToken cancellationToken)
    {
        var result = await _usuarioRolService.ObtenerAsync(usuarioId, rolId, cancellationToken);
        return Ok(ApiResponse<UsuarioRolResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearUsuarioRolRequest request, CancellationToken cancellationToken)
    {
        var ok = await _usuarioRolService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación usuario-rol creada correctamente."));
    }

    [HttpDelete("{usuarioId:int}/{rolId:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int usuarioId, int rolId, CancellationToken cancellationToken)
    {
        var ok = await _usuarioRolService.EliminarLogicoAsync(usuarioId, rolId, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación usuario-rol eliminada lógicamente."));
    }
}