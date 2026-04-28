using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.ReservaCompleta;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/reservas-completa")]
[Authorize]
public class ReservasCompletaController : ControllerBase
{
    private readonly IReservaCompletaService _reservaCompletaService;

    public ReservasCompletaController(IReservaCompletaService reservaCompletaService)
    {
        _reservaCompletaService = reservaCompletaService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<ReservaCompletaResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearReservaCompletaRequest request, CancellationToken cancellationToken)
    {
        var result = await _reservaCompletaService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<ReservaCompletaResponse>.Ok(result, "Reserva completa creada correctamente."));
    }
}