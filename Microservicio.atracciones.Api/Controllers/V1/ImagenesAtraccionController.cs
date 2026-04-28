using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.ImagenAtraccion;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/imagenes-atraccion")]
[Authorize]
public class ImagenesAtraccionController : ControllerBase
{
    private readonly IImagenAtraccionService _imagenAtraccionService;

    public ImagenesAtraccionController(IImagenAtraccionService imagenAtraccionService)
    {
        _imagenAtraccionService = imagenAtraccionService;
    }

    [HttpGet("atraccion/{atId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ImagenAtraccionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorAtraccion(int atId, CancellationToken cancellationToken)
    {
        var result = await _imagenAtraccionService.ListarPorAtraccionAsync(atId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ImagenAtraccionResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{atId:int}/{imgId:int}")]
    [ProducesResponseType(typeof(ApiResponse<ImagenAtraccionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obtener(int atId, int imgId, CancellationToken cancellationToken)
    {
        var result = await _imagenAtraccionService.ObtenerAsync(atId, imgId, cancellationToken);
        return Ok(ApiResponse<ImagenAtraccionResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearImagenAtraccionRequest request, CancellationToken cancellationToken)
    {
        var ok = await _imagenAtraccionService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación imagen-atracción creada correctamente."));
    }

    [HttpDelete("{atId:int}/{imgId:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int atId, int imgId, CancellationToken cancellationToken)
    {
        var ok = await _imagenAtraccionService.EliminarLogicoAsync(atId, imgId, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Relación imagen-atracción eliminada lógicamente."));
    }
}