using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Rol;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IRolService
{
    Task<RolResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RolResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearRolRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarRolRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}