using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Atraccion;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/atracciones")]
[Authorize]
public class AtraccionesController : ControllerBase
{
    private readonly IAtraccionService _atraccionService;

    public AtraccionesController(IAtraccionService atraccionService)
    {
        _atraccionService = atraccionService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<AtraccionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _atraccionService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<AtraccionResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<AtraccionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _atraccionService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<AtraccionResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost("buscar")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<AtraccionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Buscar([FromBody] AtraccionFiltroRequest request, CancellationToken cancellationToken)
    {
        var result = await _atraccionService.BuscarAsync(request, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<AtraccionResponse>>.Ok(result, "Consulta exitosa."));
    }
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearAtraccionRequest request, CancellationToken cancellationToken)
    {
        var id = await _atraccionService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Atracción creada correctamente."));
    }
    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarAtraccionRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _atraccionService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Atracción actualizada correctamente."));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _atraccionService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Atracción eliminada lógicamente."));
    }
    [HttpGet("{id:int}/detalle")]
    [ProducesResponseType(typeof(ApiResponse<AtraccionDetalleResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerDetalle(int id, CancellationToken cancellationToken)
    {
        var result = await _atraccionService.ObtenerDetalleAsync(id, cancellationToken);
        return Ok(ApiResponse<AtraccionDetalleResponse>.Ok(result, "Consulta exitosa."));
    }
}
