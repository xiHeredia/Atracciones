using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataAccess.Entities;
using Microservicio.atracciones.DataAccess.Repositories.Interfaces;

namespace Microservicio.atracciones.DataAccess.Repositories;

public class AtraccionRepository : IAtraccionRepository
{
    private readonly AtraccionesDbContext _context;

    public AtraccionRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<AtraccionEntity?> ObtenerPorIdAsync(int atraccionId, CancellationToken cancellationToken = default)
    {
        return await _context.Atracciones
            .AsNoTracking()
            .Include(x => x.Destino)
            .Include(x => x.CategoriasAtraccion)
                .ThenInclude(x => x.Categoria)
            .FirstOrDefaultAsync(x => x.AtId == atraccionId && x.AtEstado == "A", cancellationToken);
    }

    public async Task<AtraccionEntity?> ObtenerParaActualizarAsync(int atraccionId, CancellationToken cancellationToken = default)
    {
        return await _context.Atracciones
            .Include(x => x.Destino)
            .Include(x => x.CategoriasAtraccion)
            .FirstOrDefaultAsync(x => x.AtId == atraccionId && x.AtEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<AtraccionEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Atracciones
            .AsNoTracking()
            .Include(x => x.Destino)
            .Where(x => x.AtEstado == "A")
            .OrderBy(x => x.AtId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(AtraccionEntity atraccion, CancellationToken cancellationToken = default)
    {
        await _context.Atracciones.AddAsync(atraccion, cancellationToken);
    }

    public void Actualizar(AtraccionEntity atraccion)
    {
        _context.Atracciones.Update(atraccion);
    }
}