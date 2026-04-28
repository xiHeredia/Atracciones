using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IIdiomaRepository
{
    Task<IdiomaEntity?> ObtenerPorIdAsync(int idiomaId, CancellationToken cancellationToken = default);
    Task<IdiomaEntity?> ObtenerParaActualizarAsync(int idiomaId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<IdiomaEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(IdiomaEntity idioma, CancellationToken cancellationToken = default);
    void Actualizar(IdiomaEntity idioma);
}