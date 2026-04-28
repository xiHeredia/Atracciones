using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class FacturaConfiguration : IEntityTypeConfiguration<FacturaEntity>
{
    public void Configure(EntityTypeBuilder<FacturaEntity> builder)
    {
        builder.ToTable("facturas");

        builder.HasKey(x => x.FacId);

        builder.Property(x => x.FacId).HasColumnName("fac_id").ValueGeneratedOnAdd();
        builder.Property(x => x.FacGuid).HasColumnName("fac_guid").IsRequired();

        builder.Property(x => x.RevId).HasColumnName("rev_id").IsRequired();

        builder.Property(x => x.FacNumero).HasColumnName("fac_numero").HasMaxLength(20).IsRequired();
        builder.Property(x => x.FacFechaEmision).HasColumnName("fac_fecha_emision").IsRequired();

        builder.Property(x => x.FacTotal).HasColumnName("fac_total").HasPrecision(10, 2).IsRequired();

        builder.Property(x => x.FacObservacion).HasColumnName("fac_observacion").HasMaxLength(500);
        builder.Property(x => x.FacOrigenCanal).HasColumnName("fac_origen_canal").HasMaxLength(50).IsRequired();

        builder.Property(x => x.FacUsuarioIngreso).HasColumnName("fac_usuario_ingreso").HasMaxLength(100).IsRequired();
        builder.Property(x => x.FacIpIngreso).HasColumnName("fac_ip_ingreso").HasMaxLength(45).IsRequired();

        builder.Property(x => x.FacFechaMod).HasColumnName("fac_fecha_mod");
        builder.Property(x => x.FacUsuarioMod).HasColumnName("fac_usuario_mod").HasMaxLength(100);
        builder.Property(x => x.FacIpMod).HasColumnName("fac_ip_mod").HasMaxLength(45);

        builder.Property(x => x.FacFechaEliminacion).HasColumnName("fac_fecha_eliminacion");
        builder.Property(x => x.FacUsuarioEliminacion).HasColumnName("fac_usuario_eliminacion").HasMaxLength(100);
        builder.Property(x => x.FacIpEliminacion).HasColumnName("fac_ip_eliminacion").HasMaxLength(45);

        builder.Property(x => x.FacEstado).HasColumnName("fac_estado").HasMaxLength(1).IsRequired();
        builder.Property(x => x.FacMotivoInhabilitacion).HasColumnName("fac_motivo_inhabilitacion").HasMaxLength(300);

        builder.Property(x => x.FacRowVersion).HasColumnName("fac_row_version").IsRequired();

        builder.HasIndex(x => x.FacGuid).IsUnique();

        builder.HasOne(x => x.Reserva)
            .WithMany()
            .HasForeignKey(x => x.RevId);
    }
}