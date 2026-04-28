using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IImagenAtraccionDataService
{
    Task<ImagenAtraccionDataModel?> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenAtraccionDataModel>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task<bool> CrearAsync(ImagenAtraccionDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int atId, int imgId, CancellationToken cancellationToken = default);
}