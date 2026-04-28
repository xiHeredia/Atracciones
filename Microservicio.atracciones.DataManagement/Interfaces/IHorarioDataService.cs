using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IHorarioDataService
{
    Task<HorarioDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HorarioDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(HorarioDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(HorarioDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}