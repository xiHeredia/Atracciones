using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IReseniaRepository
{
    Task<ReseniaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ReseniaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ReseniaEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(ReseniaEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(ReseniaEntity entity);
}