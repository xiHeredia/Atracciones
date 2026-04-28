using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IAtraccionDataService
{
    Task<AtraccionDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionDataModel>> BuscarAsync(AtraccionFiltroDataModel filtro, CancellationToken cancellationToken = default);
    Task<int> CrearAsync(AtraccionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(AtraccionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
    Task<AtraccionDetalleDataModel?> ObtenerDetalleAsync(int id, CancellationToken cancellationToken = default);
}
