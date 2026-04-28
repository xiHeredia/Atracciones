using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Resenia;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/resenias")]
[Authorize]
public class ReseniasController : ControllerBase
{
    private readonly IReseniaService _reseniaService;

    public ReseniasController(IReseniaService reseniaService)
    {
        _reseniaService = reseniaService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _reseniaService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReseniaResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _reseniaService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<ReseniaResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearReseniaRequest request, CancellationToken cancellationToken)
    {
        var id = await _reseniaService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Reseña creada correctamente."));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarReseniaRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _reseniaService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Reseña actualizada correctamente."));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _reseniaService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Reseña eliminada lógicamente."));
    }
}