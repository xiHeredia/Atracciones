using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IIdiomaAtraccionDataService
{
    Task<IReadOnlyList<IdiomaAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(IdiomaAtraccionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int idId, CancellationToken cancellationToken = default);
    Task<IdiomaAtraccionDataModel?> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default);
}