using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IHorarioRepository
{
    Task<HorarioEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<HorarioEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HorarioEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(HorarioEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(HorarioEntity entity);
}