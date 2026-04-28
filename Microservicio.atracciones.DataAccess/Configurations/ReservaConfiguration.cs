using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class ReservaConfiguration : IEntityTypeConfiguration<ReservaEntity>
{
    public void Configure(EntityTypeBuilder<ReservaEntity> builder)
    {
        builder.ToTable("reservas");

        builder.HasKey(x => x.RevId);

        builder.Property(x => x.RevId).HasColumnName("rev_id").ValueGeneratedOnAdd();
        builder.Property(x => x.RevGuid).HasColumnName("rev_guid").IsRequired();
        builder.Property(x => x.RevCodigo).HasColumnName("rev_codigo").HasMaxLength(20).IsRequired();

        builder.Property(x => x.CliId).HasColumnName("cli_id").IsRequired();
        builder.Property(x => x.HorId).HasColumnName("hor_id").IsRequired();

        builder.Property(x => x.RevFechaReservaUtc).HasColumnName("rev_fecha_reserva_utc").IsRequired();

        builder.Property(x => x.RevSubtotal).HasColumnName("rev_subtotal").HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.RevValorIva).HasColumnName("rev_valor_iva").HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.RevTotal).HasColumnName("rev_total").HasPrecision(10, 2).IsRequired();

        builder.Property(x => x.RevOrigenCanal).HasColumnName("rev_origen_canal").HasMaxLength(50).IsRequired();

        builder.Property(x => x.RevUsuarioIngreso).HasColumnName("rev_usuario_ingreso").HasMaxLength(100).IsRequired();
        builder.Property(x => x.RevIpIngreso).HasColumnName("rev_ip_ingreso").HasMaxLength(45).IsRequired();

        builder.Property(x => x.RevFechaMod).HasColumnName("rev_fecha_mod");
        builder.Property(x => x.RevUsuarioMod).HasColumnName("rev_usuario_mod").HasMaxLength(100);
        builder.Property(x => x.RevIpMod).HasColumnName("rev_ip_mod").HasMaxLength(45);

        builder.Property(x => x.RevFechaCancelacion).HasColumnName("rev_fecha_cancelacion");
        builder.Property(x => x.RevUsuarioCancelacion).HasColumnName("rev_usuario_cancelacion").HasMaxLength(100);
        builder.Property(x => x.RevIpCancelacion).HasColumnName("rev_ip_cancelacion").HasMaxLength(45);
        builder.Property(x => x.RevMotivoCancelacion).HasColumnName("rev_motivo_cancelacion").HasMaxLength(300);

        builder.Property(x => x.RevEstado).HasColumnName("rev_estado").HasMaxLength(1).IsRequired();

        builder.HasIndex(x => x.RevGuid).IsUnique();

        builder.HasOne(x => x.Cliente)
            .WithMany()
            .HasForeignKey(x => x.CliId);

        builder.HasOne(x => x.Horario)
            .WithMany()
            .HasForeignKey(x => x.HorId);
    }
}
