using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IUsuarioRolDataService
{
    Task<UsuarioRolDataModel?> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioRolDataModel>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(UsuarioRolDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default);
}