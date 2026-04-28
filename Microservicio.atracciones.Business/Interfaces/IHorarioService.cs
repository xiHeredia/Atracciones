using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Horario;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IHorarioService
{
    Task<HorarioResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HorarioResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearHorarioRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarHorarioRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}