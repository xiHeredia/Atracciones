using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface ICategoriaAtraccionRepository
{
    Task<CategoriaAtraccionEntity?> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CategoriaAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default);
    Task AgregarAsync(CategoriaAtraccionEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(CategoriaAtraccionEntity entity);
}