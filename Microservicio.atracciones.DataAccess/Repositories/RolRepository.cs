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

public class RolRepository : IRolRepository
{
    private readonly AtraccionesDbContext _context;

    public RolRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<RolEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.RolId == id && x.RolEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<RolEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .AsNoTracking()
            .Where(x => x.RolEstado == "A")
            .OrderBy(x => x.RolId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(RolEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Roles.AddAsync(entity, cancellationToken);
    }

    public async Task<RolEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.RolId == id && x.RolEstado == "A", cancellationToken);
    }

    public void Actualizar(RolEntity entity)
    {
        _context.Roles.Update(entity);
    }
}