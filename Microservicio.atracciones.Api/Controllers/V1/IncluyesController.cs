using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Incluye;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/incluyes")]
[Authorize]
public class IncluyesController : ControllerBase
{
    private readonly IIncluyeService _incluyeService;

    public IncluyesController(IIncluyeService incluyeService)
    {
        _incluyeService = incluyeService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<IncluyeResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _incluyeService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<IncluyeResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<IncluyeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _incluyeService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<IncluyeResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearIncluyeRequest request, CancellationToken cancellationToken)
    {
        var id = await _incluyeService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Incluye creado correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarIncluyeRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _incluyeService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Incluye actualizado correctamente."));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _incluyeService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Incluye eliminado lógicamente."));
    }
}