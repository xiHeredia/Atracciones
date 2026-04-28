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

public class TicketRepository : ITicketRepository
{
    private readonly AtraccionesDbContext _context;

    public TicketRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<TicketEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .AsNoTracking()
            .Include(x => x.Atraccion)
            .FirstOrDefaultAsync(x => x.TckId == id && x.TckEstado == "A", cancellationToken);
    }

    public async Task<TicketEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .FirstOrDefaultAsync(x => x.TckId == id && x.TckEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<TicketEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .AsNoTracking()
            .Include(x => x.Atraccion)
            .Where(x => x.TckEstado == "A")
            .OrderBy(x => x.TckId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(TicketEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Tickets.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(TicketEntity entity)
    {
        _context.Tickets.Update(entity);
    }
}