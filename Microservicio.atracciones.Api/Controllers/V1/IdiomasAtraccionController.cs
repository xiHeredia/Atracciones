using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/idiomas-atraccion")]
[Authorize]
public class IdiomasAtraccionController : ControllerBase
{
    private readonly IIdiomaAtraccionService _service;

    public IdiomasAtraccionController(IIdiomaAtraccionService service)
    {
        _service = service;
    }

    [HttpGet("atraccion/{atId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<IdiomaAtraccionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorAtraccion(int atId, CancellationToken cancellationToken)
    {
        var result = await _service.ListarPorAtraccionAsync(atId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<IdiomaAtraccionResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{atId:int}/{idId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IdiomaAtraccionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obtener(int atId, int idId, CancellationToken cancellationToken)
    {
        var result = await _service.ObtenerAsync(atId, idId, cancellationToken);
        return Ok(ApiResponse<IdiomaAtraccionResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearIdiomaAtraccionRequest request, CancellationToken cancellationToken)
    {
        var ok = await _service.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación idioma-atracción creada correctamente."));
    }

    [HttpDelete("{atId:int}/{idId:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int atId, int idId, CancellationToken cancellationToken)
    {
        var ok = await _service.EliminarLogicoAsync(atId, idId, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación idioma-atracción eliminada lógicamente."));
    }
}