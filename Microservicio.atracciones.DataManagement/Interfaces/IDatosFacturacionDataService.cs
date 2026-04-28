using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IDatosFacturacionDataService
{
    Task<DatosFacturacionDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DatosFacturacionDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(DatosFacturacionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(DatosFacturacionDataModel model, CancellationToken cancellationToken = default);
}