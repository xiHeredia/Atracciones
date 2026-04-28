using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.Business.DTOs.Horario;
using Microservicio.atracciones.Business.Exceptions;
using Microservicio.atracciones.Business.Interfaces;
using Microservicio.atracciones.Business.Mappers;
using Microservicio.atracciones.Business.Validators;
using Microservicio.atracciones.DataManagement.Interfaces;

namespace Microservicio.atracciones.Business.Services;

public class HorarioService : IHorarioService
{
    private readonly IHorarioDataService _horarioDataService;

    public HorarioService(IHorarioDataService horarioDataService)
    {
        _horarioDataService = horarioDataService;
    }

    public async Task<HorarioResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var horario = await _horarioDataService.ObtenerPorIdAsync(id, cancellationToken);

        if (horario is null)
            throw new NotFoundException("No se encontró el horario.");

        return HorarioBusinessMapper.ToResponse(horario);
    }

    public async Task<IReadOnlyList<HorarioResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var horarios = await _horarioDataService.ListarAsync(cancellationToken);
        return horarios.Select(HorarioBusinessMapper.ToResponse).ToList();
    }

    public async Task<int> CrearAsync(CrearHorarioRequest request, CancellationToken cancellationToken = default)
    {
        var errors = HorarioValidator.ValidarCreacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var model = HorarioBusinessMapper.ToDataModel(request);
        return await _horarioDataService.CrearAsync(model, cancellationToken);
    }

    public async Task<bool> ActualizarAsync(ActualizarHorarioRequest request, CancellationToken cancellationToken = default)
    {
        var errors = HorarioValidator.ValidarActualizacion(request);

        if (errors.Any())
            throw new ValidationException("Error de validación", errors);

        var existente = await _horarioDataService.ObtenerPorIdAsync(request.Id, cancellationToken);

        if (existente is null)
            throw new NotFoundException("No se encontró el horario.");

        var model = HorarioBusinessMapper.ToDataModel(request);
        return await _horarioDataService.ActualizarAsync(model, cancellationToken);
    }

    public async Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default)
    {
        var ok = await _horarioDataService.EliminarLogicoAsync(id, cancellationToken);

        if (!ok)
            throw new NotFoundException("No se encontró el horario.");

        return true;
    }
}