using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Atraccion;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IAtraccionService
{
    Task<AtraccionResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionResponse>> BuscarAsync(AtraccionFiltroRequest request, CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearAtraccionRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarAtraccionRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
    Task<AtraccionDetalleResponse> ObtenerDetalleAsync(int id, CancellationToken cancellationToken = default);
}