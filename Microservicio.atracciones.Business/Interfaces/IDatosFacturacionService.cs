using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.DatosFacturacion;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IDatosFacturacionService
{
    Task<DatosFacturacionResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DatosFacturacionResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearDatosFacturacionRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarDatosFacturacionRequest request, CancellationToken cancellationToken = default);
}
