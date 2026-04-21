using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Common;
using Microservicio.Clientes.DataAccess.Context;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace Microservicio.Clientes.DataAccess.Queries
{
    public class ClienteQueryRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteQueryRepository(ClientesDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ClienteEntity>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default)
        {
            if (pageNumber <= 0)
                pageNumber = 1;

            if (pageSize <= 0)
                pageSize = 10;

            IQueryable<ClienteEntity> query = _context.Clientes
                .AsNoTracking()
                .Where(x => !x.EsEliminado);

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.NumeroIdentificacion.Contains(search) ||
                    (x.Nombres != null && x.Nombres.Contains(search)) ||
                    (x.Apellidos != null && x.Apellidos.Contains(search)) ||
                    (x.RazonSocial != null && x.RazonSocial.Contains(search)) ||
                    x.EstadoCliente.Contains(search));
            }

            var totalRecords = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(x => x.ClienteID)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<ClienteEntity>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IReadOnlyList<ClienteEntity>> GetActivosAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(x => !x.EsEliminado && x.EstadoCliente == "ACTIVO")
                .OrderBy(x => x.ClienteID)
                .ToListAsync(cancellationToken);
        }

        public async Task<ClienteEntity?> GetDetalleAsync(int clienteId, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ClienteID == clienteId && !x.EsEliminado, cancellationToken);
        }
    }
}
