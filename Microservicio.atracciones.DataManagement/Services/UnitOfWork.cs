using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microservicio.atracciones.DataAccess.Context;
using Microservicio.atracciones.DataAccess.Queries;
using Microservicio.atracciones.DataAccess.Repositories;
using Microservicio.atracciones.DataAccess.Repositories.Interfaces;
using Microservicio.atracciones.DataManagement.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;


namespace Microservicio.atracciones.DataManagement.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly AtraccionesDbContext _context;

    public IAtraccionRepository AtraccionRepository { get; }
    public IUsuarioRepository UsuarioRepository { get; }
    public IDestinoRepository DestinoRepository { get; }
    public ICategoriaRepository CategoriaRepository { get; }
    public IIdiomaRepository IdiomaRepository { get; }
    public IIncluyeRepository IncluyeRepository { get; }
    public IAtraccionIncluyeRepository AtraccionIncluyeRepository { get; }
    public IImagenRepository ImagenRepository { get; }
    public IImagenAtraccionRepository ImagenAtraccionRepository { get; }
    public IIdiomaAtraccionRepository IdiomaAtraccionRepository { get; }
    public ICategoriaAtraccionRepository CategoriaAtraccionRepository { get; }
    public ITicketRepository TicketRepository { get; }
    public IClienteRepository ClienteRepository { get; }
    public IHorarioRepository HorarioRepository { get; }
    public IReservaRepository ReservaRepository { get; }
    public IReservaDetalleRepository ReservaDetalleRepository { get; }
    public IReseniaRepository ReseniaRepository { get; }
    public IFacturaRepository FacturaRepository { get; }
    public IDatosFacturacionRepository DatosFacturacionRepository { get; }
    public IRolRepository RolRepository { get; }
    public IUsuarioRolRepository UsuarioRolRepository { get; }
    public AtraccionQueryRepository AtraccionQueryRepository { get; }

    public UnitOfWork(AtraccionesDbContext context)
    {
        _context = context;

        AtraccionRepository = new AtraccionRepository(_context);
        UsuarioRepository = new UsuarioRepository(_context);
        DestinoRepository = new DestinoRepository(_context);
        CategoriaRepository = new CategoriaRepository(_context);
        IdiomaRepository = new IdiomaRepository(_context);
        IncluyeRepository = new IncluyeRepository(_context);

        AtraccionIncluyeRepository = new AtraccionIncluyeRepository(_context);
        ImagenRepository = new ImagenRepository(_context);
        ImagenAtraccionRepository = new ImagenAtraccionRepository(_context);
        IdiomaAtraccionRepository = new IdiomaAtraccionRepository(_context);
        CategoriaAtraccionRepository = new CategoriaAtraccionRepository(_context);
        TicketRepository = new TicketRepository(_context);
        ClienteRepository = new ClienteRepository(_context);
        HorarioRepository = new HorarioRepository(_context);
        ReservaRepository = new ReservaRepository(_context);
        ReservaDetalleRepository = new ReservaDetalleRepository(_context);
        ReseniaRepository = new ReseniaRepository(_context);
        FacturaRepository = new FacturaRepository(_context);
        DatosFacturacionRepository = new DatosFacturacionRepository(_context);
        RolRepository = new RolRepository(_context);
        UsuarioRolRepository = new UsuarioRolRepository(_context);
        AtraccionQueryRepository = new AtraccionQueryRepository(_context);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}