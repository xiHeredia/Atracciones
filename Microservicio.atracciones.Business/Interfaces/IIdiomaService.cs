using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Idioma;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IIdiomaService
{
    Task<IdiomaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IdiomaResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearIdiomaRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarIdiomaRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}