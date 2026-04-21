using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservicio.Clientes.DataAccess.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<RolEntity>
    {
        public void Configure(EntityTypeBuilder<RolEntity> builder)
        {
            builder.ToTable("Rol", "crm");

            builder.HasKey(x => x.RolID);

            builder.Property(x => x.RolID)
                .HasColumnName("RolID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.RolGuid)
                .HasColumnName("RolGuid")
                .IsRequired();

            builder.Property(x => x.NombreRol)
                .HasColumnName("NombreRol")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsUnicode(false)
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

            builder.HasIndex(x => x.RolGuid)
                .IsUnique()
                .HasDatabaseName("UQ_Rol_RolGuid");

            builder.HasIndex(x => x.NombreRol)
                .IsUnique()
                .HasDatabaseName("UQ_Rol_NombreRol");

            builder.HasMany(x => x.UsuarioRoles)
                .WithOne(x => x.Rol)
                .HasForeignKey(x => x.RolID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}