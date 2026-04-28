using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataManagement.Models;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IImagenDataService
{
    Task<ImagenDataModel?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenDataModel>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(ImagenDataModel model, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ImagenDataModel model, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}