using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Reserva;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IReservaService
{
    Task<ReservaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReservaResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearReservaRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarReservaRequest request, CancellationToken cancellationToken = default);
    Task<bool> CancelarAsync(int id, CancelarReservaRequest request, CancellationToken cancellationToken = default);
}