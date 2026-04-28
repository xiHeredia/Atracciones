using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<ClienteEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ClienteEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(ClienteEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(ClienteEntity entity);
}