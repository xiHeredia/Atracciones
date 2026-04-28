using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IReservaDetalleDataService
{
    Task<IReadOnlyList<ReservaDetalleDataModel>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default);
    Task<int> CrearAsync(ReservaDetalleDataModel model, CancellationToken cancellationToken = default);
}