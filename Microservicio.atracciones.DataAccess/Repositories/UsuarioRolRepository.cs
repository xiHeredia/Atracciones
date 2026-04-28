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

public class UsuarioRolRepository : IUsuarioRolRepository
{
    private readonly AtraccionesDbContext _context;

    public UsuarioRolRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioRolEntity?> ObtenerAsync(int usuarioId, int rolId, CancellationToken cancellationToken = default)
    {
        return await _context.UsuarioRoles
            .Include(x => x.Usuario)
            .Include(x => x.Rol)
            .FirstOrDefaultAsync(
                x => x.UsuId == usuarioId && x.RolId == rolId && x.UsuRolEstado == "A",
                cancellationToken);
    }

    public async Task<IReadOnlyList<UsuarioRolEntity>> ListarPorUsuarioAsync(int usuarioId, CancellationToken cancellationToken = default)
    {
        return await _context.UsuarioRoles
            .AsNoTracking()
            .Include(x => x.Rol)
            .Where(x => x.UsuId == usuarioId && x.UsuRolEstado == "A")
            .OrderBy(x => x.RolId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(UsuarioRolEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.UsuarioRoles.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(UsuarioRolEntity entity)
    {
        _context.UsuarioRoles.Update(entity);
    }
}
