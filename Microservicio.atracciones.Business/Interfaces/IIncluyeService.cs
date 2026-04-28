using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Incluye;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IIncluyeService
{
    Task<IncluyeResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IncluyeResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearIncluyeRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarIncluyeRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}