using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.ReservaCompleta;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IReservaCompletaService
{
    Task<ReservaCompletaResponse> CrearAsync(CrearReservaCompletaRequest request, CancellationToken cancellationToken = default);
}