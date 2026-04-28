using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Destino;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IDestinoService
{
    Task<DestinoResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DestinoResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearDestinoRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarDestinoRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}