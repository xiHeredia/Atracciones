using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Repositories.Interfaces;

public interface IDatosFacturacionRepository
{
    Task<DatosFacturacionEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<DatosFacturacionEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DatosFacturacionEntity>> ListarAsync(CancellationToken cancellationToken = default);
    Task AgregarAsync(DatosFacturacionEntity entity, CancellationToken cancellationToken = default);
    void Actualizar(DatosFacturacionEntity entity);
}