using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservicio.Clientes.DataAccess.Configurations
{
    public class UsuarioAppConfiguration : IEntityTypeConfiguration<UsuarioAppEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioAppEntity> builder)
        {
            builder.ToTable("UsuarioApp", "crm");

            builder.HasKey(x => x.UsuarioAppID);

            builder.Property(x => x.UsuarioAppID)
                .HasColumnName("UsuarioAppID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UsuarioGuid)
                .HasColumnName("UsuarioGuid")
                .IsRequired();

            builder.Property(x => x.Username)
                .HasColumnName("Username")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasMaxLength(500)
                .IsUnicode(false)
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

            builder.HasIndex(x => x.UsuarioGuid)
                .IsUnique()
                .HasDatabaseName("UQ_UsuarioApp_UsuarioGuid");

            builder.HasIndex(x => x.Username)
                .IsUnique()
                .HasDatabaseName("UQ_UsuarioApp_Username");

            builder.HasMany(x => x.UsuarioRoles)
                .WithOne(x => x.UsuarioApp)
                .HasForeignKey(x => x.UsuarioAppID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}