using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.Factura;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/facturas")]
[Authorize]
public class FacturasController : ControllerBase
{
    private readonly IFacturaService _facturaService;

    public FacturasController(IFacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<FacturaResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _facturaService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<FacturaResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<FacturaResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _facturaService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<FacturaResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearFacturaRequest request, CancellationToken cancellationToken)
    {
        var id = await _facturaService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Factura creada correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarFacturaRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _facturaService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Factura actualizada correctamente."));
    }

    [HttpPatch("{id:int}/inhabilitar")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Inhabilitar(int id, [FromBody] InhabilitarFacturaRequest request, CancellationToken cancellationToken)
    {
        var ok = await _facturaService.InhabilitarAsync(id, request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Factura inhabilitada correctamente."));
    }
}