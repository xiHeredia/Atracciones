using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IIncluyeRepository
{
    Task<IncluyeEntity?> ObtenerPorIdAsync(int incluyeId, CancellationToken cancellationToken = default);
    Task<IncluyeEntity?> ObtenerParaActualizarAsync(int incluyeId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IncluyeEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(IncluyeEntity incluye, CancellationToken cancellationToken = default);
    void Actualizar(IncluyeEntity incluye);
}