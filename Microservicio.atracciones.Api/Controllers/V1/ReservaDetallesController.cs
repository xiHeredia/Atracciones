using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.ReservaDetalle;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/reserva-detalles")]
[Authorize]
public class ReservaDetallesController : ControllerBase
{
    private readonly IReservaDetalleService _reservaDetalleService;

    public ReservaDetallesController(IReservaDetalleService reservaDetalleService)
    {
        _reservaDetalleService = reservaDetalleService;
    }

    [HttpGet("reserva/{reservaId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ReservaDetalleResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarPorReserva(int reservaId, CancellationToken cancellationToken)
    {
        var result = await _reservaDetalleService.ListarPorReservaAsync(reservaId, cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<ReservaDetalleResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearReservaDetalleRequest request, CancellationToken cancellationToken)
    {
        var id = await _reservaDetalleService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Detalle de reserva creado correctamente."));
    }
}