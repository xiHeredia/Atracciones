using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class ReservaDetalleConfiguration : IEntityTypeConfiguration<ReservaDetalleEntity>
{
    public void Configure(EntityTypeBuilder<ReservaDetalleEntity> builder)
    {
        builder.ToTable("reserva_detalle");

        builder.HasKey(x => x.RdetId);

        builder.Property(x => x.RdetId).HasColumnName("rdet_id").ValueGeneratedOnAdd();
        builder.Property(x => x.RdetGuid).HasColumnName("rdet_guid").IsRequired();

        builder.Property(x => x.RevId).HasColumnName("rev_id").IsRequired();
        builder.Property(x => x.TckId).HasColumnName("tck_id").IsRequired();

        builder.Property(x => x.RdetCantidad).HasColumnName("rdet_cantidad").IsRequired();
        builder.Property(x => x.RdetPrecioUnit).HasColumnName("rdet_precio_unit").HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.RdetSubtotal).HasColumnName("rdet_subtotal").HasPrecision(10, 2).IsRequired();

        builder.Property(x => x.RdetFechaIngreso).HasColumnName("rdet_fecha_ingreso").IsRequired();
        builder.Property(x => x.RdetUsuarioIngreso).HasColumnName("rdet_usuario_ingreso").HasMaxLength(100).IsRequired();
        builder.Property(x => x.RdetIpIngreso).HasColumnName("rdet_ip_ingreso").HasMaxLength(45).IsRequired();

        builder.Property(x => x.RdetFechaEliminacion).HasColumnName("rdet_fecha_eliminacion");
        builder.Property(x => x.RdetUsuarioEliminacion).HasColumnName("rdet_usuario_eliminacion").HasMaxLength(100);
        builder.Property(x => x.RdetIpEliminacion).HasColumnName("rdet_ip_eliminacion").HasMaxLength(45);

        builder.Property(x => x.RdetEstado).HasColumnName("rdet_estado").HasMaxLength(1).IsRequired();

        builder.HasOne(x => x.Reserva)
            .WithMany()
            .HasForeignKey(x => x.RevId);

        builder.HasOne(x => x.Ticket)
            .WithMany()
            .HasForeignKey(x => x.TckId);
    }
}
