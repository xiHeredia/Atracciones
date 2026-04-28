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

public class ReservaDetalleRepository : IReservaDetalleRepository
{
    private readonly AtraccionesDbContext _context;

    public ReservaDetalleRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ReservaDetalleEntity>> ListarPorReservaAsync(int reservaId, CancellationToken cancellationToken = default)
    {
        return await _context.ReservaDetalles
            .AsNoTracking()
            .Where(x => x.RevId == reservaId && x.RdetEstado == "A")
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ReservaDetalleEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.ReservaDetalles.AddAsync(entity, cancellationToken);
    }
}