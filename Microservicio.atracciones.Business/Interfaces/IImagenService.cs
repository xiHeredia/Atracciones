using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Imagen;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IImagenService
{
    Task<ImagenResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearImagenRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarImagenRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}