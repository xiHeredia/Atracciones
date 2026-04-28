using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IIdiomaAtraccionService
{
    Task<IReadOnlyList<IdiomaAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CrearIdiomaAtraccionRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int idId, CancellationToken cancellationToken = default);
    Task<IdiomaAtraccionResponse> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default);
}