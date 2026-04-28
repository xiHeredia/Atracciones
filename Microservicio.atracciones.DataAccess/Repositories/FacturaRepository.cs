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

public class FacturaRepository : IFacturaRepository
{
    private readonly AtraccionesDbContext _context;

    public FacturaRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<FacturaEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Facturas
            .AsNoTracking()
            .Include(x => x.Reserva)
            .FirstOrDefaultAsync(x => x.FacId == id && x.FacEstado == "A", cancellationToken);
    }

    public async Task<FacturaEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Facturas
            .FirstOrDefaultAsync(x => x.FacId == id && x.FacEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<FacturaEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Facturas
            .AsNoTracking()
            .Include(x => x.Reserva)
            .Where(x => x.FacEstado == "A")
            .OrderBy(x => x.FacId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(FacturaEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Facturas.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(FacturaEntity entity)
    {
        _context.Facturas.Update(entity);
    }
}