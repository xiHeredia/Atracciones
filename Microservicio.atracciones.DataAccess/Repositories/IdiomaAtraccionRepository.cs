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

public class IdiomaAtraccionRepository : IIdiomaAtraccionRepository
{
    private readonly AtraccionesDbContext _context;

    public IdiomaAtraccionRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<IdiomaAtraccionEntity?> ObtenerAsync(int atId, int idId, CancellationToken cancellationToken = default)
    {
        return await _context.IdiomasAtraccion
            .Include(x => x.Idioma)
            .FirstOrDefaultAsync(
                x => x.AtId == atId && x.IdId == idId && x.IaEstado == "A",
                cancellationToken);
    }

    public async Task<IReadOnlyList<IdiomaAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        return await _context.IdiomasAtraccion
            .AsNoTracking()
            .Include(x => x.Idioma)
            .Where(x => x.AtId == atId && x.IaEstado == "A")
            .OrderBy(x => x.IdId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(IdiomaAtraccionEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.IdiomasAtraccion.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(IdiomaAtraccionEntity entity)
    {
        _context.IdiomasAtraccion.Update(entity);
    }
}