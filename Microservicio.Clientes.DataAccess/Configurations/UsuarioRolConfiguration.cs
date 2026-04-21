using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservicio.Clientes.DataAccess.Configurations
{
    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRolEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioRolEntity> builder)
        {
            builder.ToTable("UsuarioRol", "crm");

            builder.HasKey(x => x.UsuarioRolID);

            builder.Property(x => x.UsuarioRolID)
                .HasColumnName("UsuarioRolID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UsuarioAppID)
                .HasColumnName("UsuarioAppID")
                .IsRequired();

            builder.Property(x => x.RolID)
                .HasColumnName("RolID")
                .IsRequired();

            builder.Property(x => x.EsEliminado)
                .HasColumnName("EsEliminado")
                .IsRequired();

            builder.Property(x => x.CreadoPorUsuario)
                .HasColumnName("CreadoPorUsuario")
                .HasMaxLength(128)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.FechaRegistroUtc)
                .HasColumnName("FechaRegistroUtc")
                .HasColumnType("datetime2(0)")
                .IsRequired();

            builder.Property(x => x.ModificadoDesdeIP)
                .HasColumnName("ModificadoDesdeIP")
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(x => x.RowVersion)
                .HasColumnName("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.HasOne(x => x.UsuarioApp)
                .WithMany(x => x.UsuarioRoles)
                .HasForeignKey(x => x.UsuarioAppID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Rol)
                .WithMany(x => x.UsuarioRoles)
                .HasForeignKey(x => x.RolID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.UsuarioAppID, x.RolID })
                .IsUnique()
                .HasDatabaseName("UQ_UsuarioRol_UsuarioAppID_RolID");
        }
    }
}