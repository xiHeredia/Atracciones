using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IReservaRepository
{
    Task<ReservaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ReservaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReservaEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(ReservaEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(ReservaEntity entity);
}