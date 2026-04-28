using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IDestinoRepository
{
    Task<DestinoEntity?> ObtenerPorIdAsync(int destinoId, CancellationToken cancellationToken = default);
    Task<DestinoEntity?> ObtenerParaActualizarAsync(int destinoId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DestinoEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(DestinoEntity destino, CancellationToken cancellationToken = default);
    void Actualizar(DestinoEntity destino);
}