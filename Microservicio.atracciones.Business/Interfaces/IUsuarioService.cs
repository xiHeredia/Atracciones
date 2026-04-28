using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Usuario;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearUsuarioRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarUsuarioRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}