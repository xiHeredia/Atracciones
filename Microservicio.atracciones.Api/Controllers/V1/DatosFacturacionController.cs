using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microservicio.atracciones.Api.Models.Common;
using Microservicio.atracciones.Business.DTOs.DatosFacturacion;
using Microservicio.atracciones.Business.Interfaces;

namespace Microservicio.atracciones.Api.Controllers.V1;

[ApiController]
[Route("api/v1/datos-facturacion")]
[Authorize]
public class DatosFacturacionController : ControllerBase
{
    private readonly IDatosFacturacionService _datosFacturacionService;

    public DatosFacturacionController(IDatosFacturacionService datosFacturacionService)
    {
        _datosFacturacionService = datosFacturacionService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<DatosFacturacionResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var result = await _datosFacturacionService.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IReadOnlyList<DatosFacturacionResponse>>.Ok(result, "Consulta exitosa."));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<DatosFacturacionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObtenerPorId(int id, CancellationToken cancellationToken)
    {
        var result = await _datosFacturacionService.ObtenerPorIdAsync(id, cancellationToken);
        return Ok(ApiResponse<DatosFacturacionResponse>.Ok(result, "Consulta exitosa."));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Crear([FromBody] CrearDatosFacturacionRequest request, CancellationToken cancellationToken)
    {
        var id = await _datosFacturacionService.CrearAsync(request, cancellationToken);
        return Ok(ApiResponse<int>.Ok(id, "Datos de facturación creados correctamente."));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarDatosFacturacionRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        var ok = await _datosFacturacionService.ActualizarAsync(request, cancellationToken);
        return Ok(ApiResponse<bool>.Ok(ok, "Datos de facturación actualizados correctamente."));
    }
}