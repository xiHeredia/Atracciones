using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IIdiomaAtraccionRepository
{
    Task<IdiomaAtraccionEntity?> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IdiomaAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task AgregarAsync(IdiomaAtraccionEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(IdiomaAtraccionEntity entity);
}