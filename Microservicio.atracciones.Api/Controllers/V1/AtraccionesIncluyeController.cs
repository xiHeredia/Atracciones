using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.AtraccionIncluye;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/atracciones-incluye")]
[Authorize]
public class AtraccionesIncluyeController : ControllerBase
{
    private readonly IAtraccionIncluyeService _atraccionIncluyeService;

    public AtraccionesIncluyeController(IAtraccionIncluyeService atraccionIncluyeService)
    {
        _atraccionIncluyeService = atraccionIncluyeService;
    }

    [HttpGet("atraccion/{atId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<AtraccionIncluyeResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorAtraccion(int atId, CancellationToken cancellationToken)
    {
        var result = await _atraccionIncluyeService.ListarPorAtraccionAsync(atId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<AtraccionIncluyeResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{atId:int}/{incId:int}")]
    [ProducesResponseType(typeof(ApiResponse<AtraccionIncluyeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obtener(int atId, int incId, CancellationToken cancellationToken)
    {
        var result = await _atraccionIncluyeService.ObtenerAsync(atId, incId, cancellationToken);
        return Ok(ApiResponse<AtraccionIncluyeResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearAtraccionIncluyeRequest request, CancellationToken cancellationToken)
    {
        var ok = await _atraccionIncluyeService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación atracción-incluye creada correctamente."));
    }

    [HttpDelete("{atId:int}/{incId:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int atId, int incId, CancellationToken cancellationToken)
    {
        var ok = await _atraccionIncluyeService.EliminarLogicoAsync(atId, incId, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación atracción-incluye eliminada lógicamente."));
    }
}