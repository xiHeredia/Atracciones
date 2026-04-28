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

public class ReservaRepository : IReservaRepository
{
    private readonly AtraccionesDbContext _context;

    public ReservaRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<ReservaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Reservas
            .AsNoTracking()
            .Include(x => x.Cliente)
            .Include(x => x.Horario)
            .FirstOrDefaultAsync(x => x.RevId == id && x.RevEstado == "A", cancellationToken);
    }

    public async Task<ReservaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Reservas
            .FirstOrDefaultAsync(x => x.RevId == id && x.RevEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<ReservaEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Reservas
            .AsNoTracking()
            .Include(x => x.Cliente)
            .Include(x => x.Horario)
            .Where(x => x.RevEstado == "A")
            .OrderBy(x => x.RevId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ReservaEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Reservas.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(ReservaEntity entity)
    {
        _context.Reservas.Update(entity);
    }
}
