using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IDestinoDataService
{
    Task<DestinoDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DestinoDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(DestinoDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(DestinoDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}