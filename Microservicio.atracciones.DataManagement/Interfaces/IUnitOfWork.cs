using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Repositories.Interfaces;
using Microservicio.atracciones.DataAccess.Queries;

namespace Microservicio.atracciones.DataManagement.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAtraccionRepository AtraccionRepository { get; }
    IUsuarioRepository UsuarioRepository { get; }
    IDestinoRepository DestinoRepository { get; }
    ICategoriaRepository CategoriaRepository { get; }
    IIdiomaRepository IdiomaRepository { get; }
    IIncluyeRepository IncluyeRepository { get; }
    IAtraccionIncluyeRepository AtraccionIncluyeRepository { get; }
    IImagenRepository ImagenRepository { get; }
    IImagenAtraccionRepository ImagenAtraccionRepository { get; }
    IIdiomaAtraccionRepository IdiomaAtraccionRepository { get; }
    ICategoriaAtraccionRepository CategoriaAtraccionRepository { get; }
    ITicketRepository TicketRepository { get; }
    IClienteRepository ClienteRepository { get; }
    IHorarioRepository HorarioRepository { get; }
    IReservaRepository ReservaRepository { get; }
    IReservaDetalleRepository ReservaDetalleRepository { get; }
    IReseniaRepository ReseniaRepository { get; }
    IFacturaRepository FacturaRepository { get; }
    IDatosFacturacionRepository DatosFacturacionRepository { get; }
    IRolRepository RolRepository { get; }
    IUsuarioRolRepository UsuarioRolRepository { get; }
    AtraccionQueryRepository AtraccionQueryRepository { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
