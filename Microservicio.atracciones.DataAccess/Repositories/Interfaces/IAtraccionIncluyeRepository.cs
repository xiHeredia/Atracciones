using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IAtraccionIncluyeRepository
{
    Task<AtraccionIncluyeEntity?> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionIncluyeEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task AgregarAsync(AtraccionIncluyeEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(AtraccionIncluyeEntity entity);
}