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

public class AtraccionIncluyeRepository : IAtraccionIncluyeRepository
{
    private readonly AtraccionesDbContext _context;

    public AtraccionIncluyeRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<AtraccionIncluyeEntity?> ObtenerAsync(int atId, int incId, CancellationToken cancellationToken = default)
    {
        return await _context.AtraccionesIncluye
            .Include(x => x.Incluye)
            .Include(x => x.Atraccion)
            .FirstOrDefaultAsync(
                x => x.AtId == atId && x.IncId == incId && x.AiEstado == "A",
                cancellationToken);
    }

    public async Task<IReadOnlyList<AtraccionIncluyeEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        return await _context.AtraccionesIncluye
            .AsNoTracking()
            .Include(x => x.Incluye)
            .Where(x => x.AtId == atId && x.AiEstado == "A")
            .OrderBy(x => x.IncId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(AtraccionIncluyeEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.AtraccionesIncluye.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(AtraccionIncluyeEntity entity)
    {
        _context.AtraccionesIncluye.Update(entity);
    }
}