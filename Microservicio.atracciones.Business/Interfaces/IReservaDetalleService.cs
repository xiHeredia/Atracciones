using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaDetalle;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IReservaDetalleService
{
    Task<IReadOnlyList<ReservaDetalleResponse>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearReservaDetalleRequest request, CancellationToken cancellationToken = default);
}