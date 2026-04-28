using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IIncluyeDataService
{
    Task<IncluyeDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IncluyeDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(IncluyeDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(IncluyeDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}