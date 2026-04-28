using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IUsuarioDataService
{
    Task<UsuarioDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<UsuarioDataModel?> ObtenerPorLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(UsuarioDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(UsuarioDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}