using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.Business.DTOs.ImagenAtraccion;

namespace Microservicio.atracciones.Business.Interfaces;

public interface IImagenAtraccionService
{
    Task<ImagenAtraccionResponse> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenAtraccionResponse>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(CrearImagenAtraccionRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int imgId, CancellationToken cancellationToken = default);
}