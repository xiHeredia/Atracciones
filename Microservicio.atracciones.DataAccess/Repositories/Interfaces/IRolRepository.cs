using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IRolRepository
{
    Task<RolEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<RolEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(RolEntity entity, CancellationToken cancellationToken = default);
    Task<RolEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    void Actualizar(RolEntity entity);
}