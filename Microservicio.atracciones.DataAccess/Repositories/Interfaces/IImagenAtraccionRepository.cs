using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IImagenAtraccionRepository
{
    Task<ImagenAtraccionEntity?> ObtenerAsync(int atId, int imgId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task AgregarAsync(ImagenAtraccionEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(ImagenAtraccionEntity entity);
}