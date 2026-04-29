using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IClienteDataService
{
    Task<ClienteDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteDataModel?> ObtenerPorUsuarioIdAsync(int usuarioId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ClienteDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(ClienteDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ClienteDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}
