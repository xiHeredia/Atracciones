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

public class DestinoRepository : IDestinoRepository
{
    private readonly AtraccionesDbContext _context;

    public DestinoRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<DestinoEntity?> ObtenerPorIdAsync(int destinoId, CancellationToken cancellationToken = default)
    {
        return await _context.Destinos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DesId == destinoId && x.DesEstado == "A", cancellationToken);
    }

    public async Task<DestinoEntity?> ObtenerParaActualizarAsync(int destinoId, CancellationToken cancellationToken = default)
    {
        return await _context.Destinos
            .FirstOrDefaultAsync(x => x.DesId == destinoId && x.DesEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<DestinoEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Destinos
            .AsNoTracking()
            .Where(x => x.DesEstado == "A")
            .OrderBy(x => x.DesId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(DestinoEntity destino, CancellationToken cancellationToken = default)
    {
        await _context.Destinos.AddAsync(destino, cancellationToken);
    }

    public void Actualizar(DestinoEntity destino)
    {
        _context.Destinos.Update(destino);
    }
}