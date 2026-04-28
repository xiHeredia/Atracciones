using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Queries;

public class AtraccionQueryRepository
{
    private readonly AtraccionesDbContext _context;

    public AtraccionQueryRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<AtraccionEntity>> BuscarAsync(
        string? nombre,
        int? destinoId,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Atracciones
            .AsNoTracking()
            .Include(x => x.Destino)
            .Where(x => x.AtEstado == "A");

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            query = query.Where(x => x.AtNombre.Contains(nombre));
        }

        if (destinoId.HasValue)
        {
            query = query.Where(x => x.DesId == destinoId.Value);
        }

        return await query
            .OrderBy(x => x.AtNombre)
            .ToListAsync(cancellationToken);
    }
}