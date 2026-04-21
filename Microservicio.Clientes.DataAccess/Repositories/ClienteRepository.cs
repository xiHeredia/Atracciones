using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace Microservicio.Clientes.DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteRepository(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task<ClienteEntity?> GetByIdAsync(int clienteId, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(x => x.ClienteID == clienteId, cancellationToken);
        }

        public async Task<ClienteEntity?> GetByGuidAsync(Guid clienteGuid, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(x => x.ClienteGuid == clienteGuid, cancellationToken);
        }

        public async Task<ClienteEntity?> GetByNumeroIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(x => x.NumeroIdentificacion == numeroIdentificacion, cancellationToken);
        }

        public async Task<IReadOnlyList<ClienteEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .AsNoTracking()
                .OrderBy(x => x.ClienteID)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ClienteEntity>> GetActivosAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(x => !x.EsEliminado && x.EstadoCliente != "ELIMINADO")
                .OrderBy(x => x.ClienteID)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsByNumeroIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .AnyAsync(x => x.NumeroIdentificacion == numeroIdentificacion, cancellationToken);
        }

        public async Task AddAsync(ClienteEntity cliente, CancellationToken cancellationToken = default)
        {
            await _context.Clientes.AddAsync(cliente, cancellationToken);
        }

        public void Update(ClienteEntity cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public async Task SoftDeleteAsync(int clienteId, string? ip, CancellationToken cancellationToken = default)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(x => x.ClienteID == clienteId, cancellationToken);

            if (cliente is null)
                return;

            cliente.EsEliminado = true;
            cliente.EstadoCliente = "ELIMINADO";
            cliente.ModificadoDesdeIP = ip;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}