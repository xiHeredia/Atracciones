using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IAtraccionIncluyeDataService
{
    Task<AtraccionIncluyeDataModel?> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionIncluyeDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(AtraccionIncluyeDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int incId, CancellationToken cancellationToken = default);
}