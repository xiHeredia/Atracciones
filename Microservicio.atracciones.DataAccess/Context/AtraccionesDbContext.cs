using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Context;

public class AtraccionesDbContext : DbContext
{
    public AtraccionesDbContext(DbContextOptions<AtraccionesDbContext> options)
        : base(options)
    {
    }

    public DbSet<UsuarioEntity> Usuarios => Set<UsuarioEntity>();
    public DbSet<RolEntity> Roles => Set<RolEntity>();
    public DbSet<UsuarioRolEntity> UsuarioRoles => Set<UsuarioRolEntity>();

    public DbSet<DestinoEntity> Destinos => Set<DestinoEntity>();
    public DbSet<CategoriaEntity> Categorias => Set<CategoriaEntity>();
    public DbSet<AtraccionEntity> Atracciones => Set<AtraccionEntity>();
    public DbSet<IdiomaEntity> Idiomas => Set<IdiomaEntity>();
    public DbSet<IncluyeEntity> Incluyes => Set<IncluyeEntity>();
    public DbSet<CategoriaAtraccionEntity> CategoriaAtracciones => Set<CategoriaAtraccionEntity>();
    public DbSet<AtraccionIncluyeEntity> AtraccionesIncluye => Set<AtraccionIncluyeEntity>();
    public DbSet<ImagenEntity> Imagenes => Set<ImagenEntity>();
    public DbSet<ImagenAtraccionEntity> ImagenesAtraccion => Set<ImagenAtraccionEntity>();
    public DbSet<IdiomaAtraccionEntity> IdiomasAtraccion => Set<IdiomaAtraccionEntity>();
    public DbSet<TicketEntity> Tickets => Set<TicketEntity>();
    public DbSet<ClienteEntity> Clientes => Set<ClienteEntity>();
    public DbSet<HorarioEntity> Horarios => Set<HorarioEntity>();
    public DbSet<ReservaEntity> Reservas => Set<ReservaEntity>();
    public DbSet<ReservaDetalleEntity> ReservaDetalles => Set<ReservaDetalleEntity>();
    public DbSet<ReseniaEntity> Resenias => Set<ReseniaEntity>();
    public DbSet<FacturaEntity> Facturas => Set<FacturaEntity>();
    public DbSet<DatosFacturacionEntity> DatosFacturacion => Set<DatosFacturacionEntity>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aquí luego vamos a aplicar todas las configuraciones
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AtraccionesDbContext).Assembly);
    }
}
