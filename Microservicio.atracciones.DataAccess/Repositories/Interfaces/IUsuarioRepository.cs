using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<UsuarioEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<UsuarioEntity?> ObtenerPorLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<UsuarioEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UsuarioEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(UsuarioEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(UsuarioEntity entity);
}