using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataAccess.Repositories.Interfaces;

namespace Microservicio.atracciones.DataAccess.Repositories;

public class IdiomaRepository : IIdiomaRepository
{
    private readonly AtraccionesDbContext _context;

    public IdiomaRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<IdiomaEntity?> ObtenerPorIdAsync(int idiomaId, CancellationToken cancellationToken = default)
    {
        return await _context.Idiomas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdiId == idiomaId && x.IdiEstado == "A", cancellationToken);
    }

    public async Task<IdiomaEntity?> ObtenerParaActualizarAsync(int idiomaId, CancellationToken cancellationToken = default)
    {
        return await _context.Idiomas
            .FirstOrDefaultAsync(x => x.IdiId == idiomaId && x.IdiEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<IdiomaEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Idiomas
            .AsNoTracking()
            .Where(x => x.IdiEstado == "A")
            .OrderBy(x => x.IdiId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(IdiomaEntity idioma, CancellationToken cancellationToken = default)
    {
        await _context.Idiomas.AddAsync(idioma, cancellationToken);
    }

    public void Actualizar(IdiomaEntity idioma)
    {
        _context.Idiomas.Update(idioma);
    }
}