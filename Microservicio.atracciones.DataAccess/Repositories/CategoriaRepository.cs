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

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AtraccionesDbContext _context;

    public CategoriaRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<CategoriaEntity?> ObtenerPorIdAsync(int categoriaId, CancellationToken cancellationToken = default)
    {
        return await _context.Categorias
            .AsNoTracking()
            .Include(x => x.CategoriaPadre)
            .FirstOrDefaultAsync(x => x.CatId == categoriaId && x.CatEstado == "A", cancellationToken);
    }

    public async Task<CategoriaEntity?> ObtenerParaActualizarAsync(int categoriaId, CancellationToken cancellationToken = default)
    {
        return await _context.Categorias
            .FirstOrDefaultAsync(x => x.CatId == categoriaId && x.CatEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<CategoriaEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Categorias
            .AsNoTracking()
            .Include(x => x.CategoriaPadre)
            .Where(x => x.CatEstado == "A")
            .OrderBy(x => x.CatId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(CategoriaEntity categoria, CancellationToken cancellationToken = default)
    {
        await _context.Categorias.AddAsync(categoria, cancellationToken);
    }

    public void Actualizar(CategoriaEntity categoria)
    {
        _context.Categorias.Update(categoria);
    }
}