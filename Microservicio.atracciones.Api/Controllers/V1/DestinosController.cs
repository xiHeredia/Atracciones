using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Destino;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/destinos")]
[Authorize]
public class DestinosController : ControllerBase
{
    private readonly IDestinoService _destinoService;

    public DestinosController(IDestinoService destinoService)
    {
        _destinoService = destinoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<DestinoResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _destinoService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<DestinoResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<DestinoResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _destinoService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<DestinoResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearDestinoRequest request, CancellationToken cancellationToken)
    {
        var id = await _destinoService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Destino creado correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarDestinoRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _destinoService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Destino actualizado correctamente."));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _destinoService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Destino eliminado lógicamente."));
    }
}