using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Horario;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/horarios")]
[Authorize]
public class HorariosController : ControllerBase
{
    private readonly IHorarioService _horarioService;

    public HorariosController(IHorarioService horarioService)
    {
        _horarioService = horarioService;
    }

    [HttpGet]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _horarioService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<HorarioResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _horarioService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<HorarioResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] CrearHorarioRequest request, CancellationToken cancellationToken)
    {
        var id = await _horarioService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Horario creado correctamente."));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarHorarioRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _horarioService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Horario actualizado correctamente."));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> EliminarLogico(int id, CancellationToken cancellationToken)
    {
        var ok = await _horarioService.EliminarLogicoAsync(id, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Horario eliminado lógicamente."));
    }
}