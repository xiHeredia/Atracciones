using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IReservaDataService
{
    Task<ReservaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReservaDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(ReservaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ReservaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> CancelarAsync(int id, string motivo, CancellationToken cancellationToken = default);
}