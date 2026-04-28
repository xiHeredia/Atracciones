using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IUsuarioRolRepository
{
    Task<UsuarioRolEntity?> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioRolEntity>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default);
    Task AgregarAsync(UsuarioRolEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(UsuarioRolEntity entity);
}