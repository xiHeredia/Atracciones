using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IFacturaRepository
{
    Task<FacturaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<FacturaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<FacturaEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(FacturaEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(FacturaEntity entity);
}