using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.Business.DTOs.Categoria;

namespace Microservicio.atracciones.Business.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaResponse> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CategoriaResponse>> ListarAsync(CancellationToken cancellationToken = default);
    Task<int> CrearAsync(CrearCategoriaRequest request, CancellationToken cancellationToken = default);
    Task<bool> ActualizarAsync(ActualizarCategoriaRequest request, CancellationToken cancellationToken = default);
    Task<bool> EliminarLogicoAsync(int id, CancellationToken cancellationToken = default);
}