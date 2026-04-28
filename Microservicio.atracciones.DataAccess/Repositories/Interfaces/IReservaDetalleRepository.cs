using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IReservaDetalleRepository
{
    Task<IReadOnlyList<ReservaDetalleEntity>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default);
    Task AgregarAsync(ReservaDetalleEntity entity, CancellationToken cancellationToken = default);
}
