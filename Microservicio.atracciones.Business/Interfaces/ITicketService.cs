using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Ticket;

namespace Microservicio.atracciones.Business.Interfaces;

public interface ITicketService
{
    Task<TicketResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TicketResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearTicketRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarTicketRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}