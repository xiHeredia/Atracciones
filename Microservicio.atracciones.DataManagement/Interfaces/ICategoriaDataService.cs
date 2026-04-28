using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface ICategoriaDataService
{
    Task<CategoriaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CategoriaDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CategoriaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(CategoriaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}