using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.CategoriaAtraccion;

namespace Microservicio.atracciones.Business.Interfaces;

public interface ICategoriaAtraccionService
{
    Task<CategoriaAtraccionResponse> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CategoriaAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CrearCategoriaAtraccionRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int catId, CancellationToken cancellationToken = default);
}