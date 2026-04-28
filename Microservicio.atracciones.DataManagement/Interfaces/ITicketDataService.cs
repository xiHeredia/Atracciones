using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface ITicketDataService
{
    Task<TicketDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TicketDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(TicketDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(TicketDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}