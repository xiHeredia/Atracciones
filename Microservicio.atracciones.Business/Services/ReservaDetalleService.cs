using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaDetalle;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class ReservaDetalleService : IReservaDetalleService
{
    private readonly IReservaDetalleDataService _reservaDetalleDataService;

    public ReservaDetalleService(IReservaDetalleDataService reservaDetalleDataService)
    {
        _reservaDetalleDataService = reservaDetalleDataService;
    }

    public async Task<IReadOnlyList<ReservaDetalleResponse>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default)
    {
        var detalles = await _reservaDetalleDataService.ListarPorReservaAsync(reservaId, cancellationToken);
        return detalles.Select(ReservaDetalleBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearReservaDetalleRequest request, CancellationToken cancellationToken = default)
    {
        var errors = ReservaDetalleValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = ReservaDetalleBusinessMapper.ToDataModel(request);
        return await _reservaDetalleDataService.CrearAsync(model, cancellationToken);
    }
}