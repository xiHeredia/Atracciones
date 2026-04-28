using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Reserva;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/reservas")]
[Authorize]
public class ReservasController : ControllerBase
{
    private readonly IReservaService _reservaService;

    public ReservasController(IReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ReservaResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _reservaService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReservaResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<ReservaResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _reservaService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<ReservaResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearReservaRequest request, CancellationToken cancellationToken)
    {
        var id = await _reservaService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Reserva creada correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarReservaRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _reservaService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Reserva actualizada correctamente."));
    }

    [HttpPatch("{id:int}/cancelar")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Cancelar(int id, [FromBody] CancelarReservaRequest request, CancellationToken cancellationToken)
    {
        var ok = await _reservaService.CancelarAsync(id, request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Reserva cancelada correctamente."));
    }
}