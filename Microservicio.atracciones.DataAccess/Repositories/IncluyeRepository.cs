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

public class IncluyeRepository : IIncluyeRepository
{
    private readonly AtraccionesDbContext _context;

    public IncluyeRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<IncluyeEntity?> ObtenerPorIdAsync(int incluyeId, CancellationToken cancellationToken = default)
    {
        return await _context.Incluyes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IncId == incluyeId && x.IncEstado == "A", cancellationToken);
    }

    public async Task<IncluyeEntity?> ObtenerParaActualizarAsync(int incluyeId, CancellationToken cancellationToken = default)
    {
        return await _context.Incluyes
            .FirstOrDefaultAsync(x => x.IncId == incluyeId && x.IncEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<IncluyeEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Incluyes
            .AsNoTracking()
            .Where(x => x.IncEstado == "A")
            .OrderBy(x => x.IncId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(IncluyeEntity incluye, CancellationToken cancellationToken = default)
    {
        await _context.Incluyes.AddAsync(incluye, cancellationToken);
    }

    public void Actualizar(IncluyeEntity incluye)
    {
        _context.Incluyes.Update(incluye);
    }
}