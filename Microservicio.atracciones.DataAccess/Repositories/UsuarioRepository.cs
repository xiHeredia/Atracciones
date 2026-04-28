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

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AtraccionesDbContext _context;

    public UsuarioRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .Include(x => x.UsuarioRoles)
                .ThenInclude(x => x.Rol)
            .FirstOrDefaultAsync(x => x.UsuId == id && x.UsuEstado == "A", cancellationToken);
    }

    public async Task<UsuarioEntity?> ObtenerPorLoginAsync(string login, CancellationToken cancellationToken = default)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .Include(x => x.UsuarioRoles)
                .ThenInclude(x => x.Rol)
            .FirstOrDefaultAsync(x => x.UsuLogin == login && x.UsuEstado == "A", cancellationToken);
    }

    public async Task<UsuarioEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(x => x.UsuId == id && x.UsuEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<UsuarioEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Usuarios
            .AsNoTracking()
            .Include(x => x.UsuarioRoles)
                .ThenInclude(x => x.Rol)
            .Where(x => x.UsuEstado == "A")
            .OrderBy(x => x.UsuId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(UsuarioEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Usuarios.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(UsuarioEntity entity)
    {
        _context.Usuarios.Update(entity);
    }
}