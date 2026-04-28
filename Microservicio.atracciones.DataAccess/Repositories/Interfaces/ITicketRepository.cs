using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface ITicketRepository
{
    Task<TicketEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TicketEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TicketEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(TicketEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(TicketEntity entity);
}