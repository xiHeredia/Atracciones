using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IReseniaDataService
{
    Task<ReseniaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReseniaDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(ReseniaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ReseniaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}