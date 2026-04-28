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

public class ReseniaRepository : IReseniaRepository
{
    private readonly AtraccionesDbContext _context;

    public ReseniaRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<ReseniaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Resenias
            .AsNoTracking()
            .Include(x => x.Atraccion)
            .Include(x => x.Reserva)
            .FirstOrDefaultAsync(x => x.RsnId == id && x.RsnEstado == "A", cancellationToken);
    }

    public async Task<ReseniaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Resenias
            .FirstOrDefaultAsync(x => x.RsnId == id && x.RsnEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<ReseniaEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Resenias
            .AsNoTracking()
            .Include(x => x.Atraccion)
            .Include(x => x.Reserva)
            .Where(x => x.RsnEstado == "A")
            .OrderBy(x => x.RsnId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ReseniaEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Resenias.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(ReseniaEntity entity)
    {
        _context.Resenias.Update(entity);
    }
}