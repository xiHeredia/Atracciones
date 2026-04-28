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

public class CategoriaAtraccionRepository : ICategoriaAtraccionRepository
{
    private readonly AtraccionesDbContext _context;

    public CategoriaAtraccionRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<CategoriaAtraccionEntity?> ObtenerAsync(int atId, int catId, CancellationToken cancellationToken = default)
    {
        return await _context.CategoriaAtracciones
            .Include(x => x.Categoria)
            .FirstOrDefaultAsync(
                x => x.AtId == atId && x.CatId == catId && x.CaEstado == "A",
                cancellationToken);
    }

    public async Task<IReadOnlyList<CategoriaAtraccionEntity>> ListarPorAtraccionAsync(int atId, CancellationToken cancellationToken = default)
    {
        return await _context.CategoriaAtracciones
            .AsNoTracking()
            .Include(x => x.Categoria)
            .Where(x => x.AtId == atId && x.CaEstado == "A")
            .OrderBy(x => x.CatId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(CategoriaAtraccionEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.CategoriaAtracciones.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(CategoriaAtraccionEntity entity)
    {
        _context.CategoriaAtracciones.Update(entity);
    }
}