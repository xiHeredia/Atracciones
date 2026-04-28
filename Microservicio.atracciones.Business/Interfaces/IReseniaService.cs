using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Resenia;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IReseniaService
{
    Task<ReseniaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReseniaResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearReseniaRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarReseniaRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}