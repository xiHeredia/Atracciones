using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IRolDataService
{
    Task<RolDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RolDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(RolDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(RolDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}