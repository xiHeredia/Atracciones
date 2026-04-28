using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.UsuarioRol;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IUsuarioRolService
{
    Task<UsuarioRolResponse> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioRolResponse>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CrearUsuarioRolRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default);
}