using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Idioma;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/idiomas")]
[Authorize]
public class IdiomasController : ControllerBase
{
    private readonly IIdiomaService _idiomaService;

    public IdiomasController(IIdiomaService idiomaService)
    {
        _idiomaService = idiomaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<IdiomaResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _idiomaService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<IdiomaResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<IdiomaResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _idiomaService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<IdiomaResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearIdiomaRequest request, CancellationToken cancellationToken)
    {
        var id = await _idiomaService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Idioma creado correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarIdiomaRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _idiomaService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Idioma actualizado correctamente."));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _idiomaService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Idioma eliminado lógicamente."));
    }
}