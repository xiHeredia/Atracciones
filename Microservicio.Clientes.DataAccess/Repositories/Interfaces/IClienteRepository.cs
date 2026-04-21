using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;

namespace Microservicio.Clientes.DataAccess.Repositories
{
    public interface IClienteRepository
    {
        Task<ClienteEntity?> GetByIdAsync(int clienteId, CancellationToken cancellationToken = default);

        Task<ClienteEntity?> GetByGuidAsync(Guid clienteGuid, CancellationToken cancellationToken = default);

        Task<ClienteEntity?> GetByNumeroIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ClienteEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ClienteEntity>> GetActivosAsync(CancellationToken cancellationToken = default);

        Task<bool> ExistsByNumeroIdentificacionAsync(string numeroIdentificacion, CancellationToken cancellationToken = default);

        Task AddAsync(ClienteEntity cliente, CancellationToken cancellationToken = default);

        void Update(ClienteEntity cliente);

        Task SoftDeleteAsync(int clienteId, string? ip, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
