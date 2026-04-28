using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.AtraccionIncluye;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IAtraccionIncluyeService
{
    Task<AtraccionIncluyeResponse> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionIncluyeResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CrearAtraccionIncluyeRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int incId, CancellationToken cancellationToken = default);
}