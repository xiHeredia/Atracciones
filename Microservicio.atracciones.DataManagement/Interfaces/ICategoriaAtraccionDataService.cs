using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface ICategoriaAtraccionDataService
{
    Task<CategoriaAtraccionDataModel?> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CategoriaAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CategoriaAtraccionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int catId, CancellationToken cancellationToken = default);
}