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

public class ClienteRepository : IClienteRepository
{
    private readonly AtraccionesDbContext _context;

    public ClienteRepository(AtraccionesDbContext context)
    {
        _context = context;
    }

    public async Task<ClienteEntity?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Clientes
            .AsNoTracking()
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.CliId == id && x.CliEstado == "A", cancellationToken);
    }

    public async Task<ClienteEntity?> ObtenerParaActualizarAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(x => x.CliId == id && x.CliEstado == "A", cancellationToken);
    }

    public async Task<IReadOnlyList<ClienteEntity>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Clientes
            .AsNoTracking()
            .Include(x => x.Usuario)
            .Where(x => x.CliEstado == "A")
            .OrderBy(x => x.CliId)
            .ToListAsync(cancellationToken);
    }

    public async Task AgregarAsync(ClienteEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Clientes.AddAsync(entity, cancellationToken);
    }

    public void Actualizar(ClienteEntity entity)
    {
        _context.Clientes.Update(entity);
    }
}