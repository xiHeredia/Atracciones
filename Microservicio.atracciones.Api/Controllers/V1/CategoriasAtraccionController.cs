using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/categorias-atraccion")]
[Authorize]
public class CategoriasAtraccionController : ControllerBase
{
    private readonly ICategoriaAtraccionService _service;

    public CategoriasAtraccionController(ICategoriaAtraccionService service)
    {
        _service = service;
    }

    [HttpGet("atraccion/{atId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<CategoriaAtraccionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorAtraccion(int atId, CancellationToken cancellationToken)
    {
        var result = await _service.ListarPorAtraccionAsync(atId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<CategoriaAtraccionResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{atId:int}/{catId:int}")]
    [ProducesResponseType(typeof(ApiResponse<CategoriaAtraccionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obtener(int atId, int catId, CancellationToken cancellationToken)
    {
        var result = await _service.ObtenerAsync(atId, catId, cancellationToken);
        return Ok(ApiResponse<CategoriaAtraccionResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearCategoriaAtraccionRequest request, CancellationToken cancellationToken)
    {
        var ok = await _service.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación categoría-atracción creada correctamente."));
    }

    [HttpDelete("{atId:int}/{catId:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int atId, int catId, CancellationToken cancellationToken)
    {
        var ok = await _service.EliminarLogicoAsync(atId, catId, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación categoría-atracción eliminada lógicamente."));
    }
}