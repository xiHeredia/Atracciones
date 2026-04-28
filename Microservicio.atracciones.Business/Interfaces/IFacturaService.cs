using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Factura;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IFacturaService
{
    Task<FacturaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<FacturaResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearFacturaRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarFacturaRequest request, CancellationToken cancellationToken = default);
    Task<bool> InhabilitarAsync(int id, InhabilitarFacturaRequest request, CancellationToken cancellationToken = default);
}