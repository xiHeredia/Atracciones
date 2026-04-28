using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IAtraccionRepository
{
    Task<AtraccionEntity?> ObtenerPorIdAsync(int atraccionId, CancellationToken cancellationToken = default);
    Task<AtraccionEntity?> ObtenerParaActualizarAsync(int atraccionId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AtraccionEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(AtraccionEntity atraccion, CancellationToken cancellationToken = default);
    void Actualizar(AtraccionEntity atraccion);
}