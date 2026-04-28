using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Rol;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/roles")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly IRolService _rolService;

    public RolesController(IRolService rolService)
    {
        _rolService = rolService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<RolResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _rolService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<RolResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<RolResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _rolService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<RolResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearRolRequest request, CancellationToken cancellationToken)
    {
        var id = await _rolService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Rol creado correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarRolRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _rolService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Rol actualizado correctamente."));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _rolService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Rol eliminado lógicamente."));
    }
}