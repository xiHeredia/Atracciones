using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
{
    public void Configure(EntityTypeBuilder<TicketEntity> builder)
    {
        builder.ToTable("ticket");

        builder.HasKey(x => x.TckId);

        builder.Property(x => x.TckId).HasColumnName("tck_id").ValueGeneratedOnAdd();
        builder.Property(x => x.TckGuid).HasColumnName("tck_guid").IsRequired();
        builder.Property(x => x.AtId).HasColumnName("at_id").IsRequired();

        builder.Property(x => x.TckTitulo).HasColumnName("tck_titulo").HasMaxLength(150).IsRequired();
        builder.Property(x => x.TckPrecio).HasColumnName("tck_precio").HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.TckTipoParticipante).HasColumnName("tck_tipo_participante").HasMaxLength(30).IsRequired();
        builder.Property(x => x.TckCapacidadMaxima).HasColumnName("tck_capacidad_maxima").IsRequired();
        builder.Property(x => x.TckCuposDisponibles).HasColumnName("tck_cupos_disponibles").IsRequired();

        builder.Property(x => x.TckFechaIngreso).HasColumnName("tck_fecha_ingreso").IsRequired();
        builder.Property(x => x.TckUsuarioIngreso).HasColumnName("tck_usuario_ingreso").HasMaxLength(100).IsRequired();
        builder.Property(x => x.TckIpIngreso).HasColumnName("tck_ip_ingreso").HasMaxLength(45).IsRequired();

        builder.Property(x => x.TckFechaMod).HasColumnName("tck_fecha_mod");
        builder.Property(x => x.TckUsuarioMod).HasColumnName("tck_usuario_mod").HasMaxLength(100);
        builder.Property(x => x.TckIpMod).HasColumnName("tck_ip_mod").HasMaxLength(45);

        builder.Property(x => x.TckFechaEliminacion).HasColumnName("tck_fecha_eliminacion");
        builder.Property(x => x.TckUsuarioEliminacion).HasColumnName("tck_usuario_eliminacion").HasMaxLength(100);
        builder.Property(x => x.TckIpEliminacion).HasColumnName("tck_ip_eliminacion").HasMaxLength(45);

        builder.Property(x => x.TckEstado).HasColumnName("tck_estado").HasMaxLength(1).IsRequired();

        builder.HasIndex(x => x.TckGuid).IsUnique();

        builder.HasOne(x => x.Atraccion)
            .WithMany()
            .HasForeignKey(x => x.AtId);
    }
}