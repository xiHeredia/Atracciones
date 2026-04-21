using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservicio.Clientes.DataAccess.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente", "crm");

            builder.HasKey(x => x.ClienteID);

            builder.Property(x => x.ClienteID)
                .HasColumnName("ClienteID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ClienteGuid)
                .HasColumnName("ClienteGuid")
                .IsRequired();

            builder.Property(x => x.TipoIdentificacion)
                .HasColumnName("TipoIdentificacion")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NumeroIdentificacion)
                .HasColumnName("NumeroIdentificacion")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Nombres)
                .HasColumnName("Nombres")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(x => x.Apellidos)
                .HasColumnName("Apellidos")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(x => x.RazonSocial)
                .HasColumnName("RazonSocial")
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(x => x.EstadoCliente)
                .HasColumnName("EstadoCliente")
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

            builder.HasIndex(x => x.ClienteGuid)
                .IsUnique()
                .HasDatabaseName("UQ_Cliente_ClienteGuid");

            builder.HasIndex(x => x.NumeroIdentificacion)
                .IsUnique()
                .HasDatabaseName("UQ_Cliente_NumeroIdentificacion");
        }
    }
}
