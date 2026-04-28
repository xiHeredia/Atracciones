using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IFacturaDataService
{
    Task<FacturaDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<FacturaDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(FacturaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(FacturaDataModel model, CancellationToken cancellationToken = default);
    Task<bool> InhabilitarAsync(int id, string motivo, CancellationToken cancellationToken = default);
}