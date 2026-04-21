using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Configurations;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicio.Clientes.DataAccess.Context
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<UsuarioAppEntity> UsuariosApp { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<UsuarioRolEntity> UsuariosRoles { get; set; }
        public DbSet<AuditoriaEntity> Auditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioAppConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriaConfiguration());
        }
    }
}