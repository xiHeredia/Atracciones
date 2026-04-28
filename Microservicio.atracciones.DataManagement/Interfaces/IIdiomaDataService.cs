using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IIdiomaDataService
{
    Task<IdiomaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IdiomaDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(IdiomaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(IdiomaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}