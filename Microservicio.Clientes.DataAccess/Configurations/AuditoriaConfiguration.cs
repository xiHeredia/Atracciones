using System;
using System.Collections.Generic;
using System.Text;
using Microservicio.Clientes.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservicio.Clientes.DataAccess.Configurations
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<AuditoriaEntity>
    {
        public void Configure(EntityTypeBuilder<AuditoriaEntity> builder)
        {
            builder.ToTable("ClienteLog", "crm");

            builder.HasKey(x => x.AuditoriaID);

            builder.Property(x => x.AuditoriaID)
                .HasColumnName("LogID")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Tabla)
                .HasColumnName("Tabla")
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(x => x.TipoOperacion)
                .HasColumnName("TipoOperacion")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Usuario)
                .HasColumnName("EjecutadoPorUsuario")
                .HasMaxLength(128)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(x => x.FechaEventoUtc)
                .HasColumnName("FechaEventoUtc")
                .HasColumnType("datetime2(0)")
                .IsRequired();

            builder.Property(x => x.IpOrigen)
                .HasColumnName("EjecutadoDesdeIP")
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(x => x.DatosAntes)
                .HasColumnName("DatosAntes")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.DatosDespues)
                .HasColumnName("DatosDespues")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
        }
    }
}   