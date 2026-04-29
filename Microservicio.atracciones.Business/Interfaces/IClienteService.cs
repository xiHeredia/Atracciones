using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Cliente;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IClienteService
{
    Task<ClienteResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteResponse?> ObtenerPorUsuarioIdAsync(int usuarioId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ClienteResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearClienteRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarClienteRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}
