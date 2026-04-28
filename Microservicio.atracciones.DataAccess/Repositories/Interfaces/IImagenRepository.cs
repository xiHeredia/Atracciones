using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IImagenRepository
{
    Task<ImagenEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ImagenEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ImagenEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(ImagenEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(ImagenEntity entity);
}