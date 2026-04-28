using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class HorarioConfiguration : IEntityTypeConfiguration<HorarioEntity>
{
    public void Configure(EntityTypeBuilder<HorarioEntity> builder)
    {
        builder.ToTable("horario");

        builder.HasKey(x => x.HorId);

        builder.Property(x => x.HorId).HasColumnName("hor_id").ValueGeneratedOnAdd();
        builder.Property(x => x.HorGuid).HasColumnName("hor_guid").IsRequired();

        builder.Property(x => x.TckId).HasColumnName("tck_id").IsRequired();

        builder.Property(x => x.HorFecha).HasColumnName("hor_fecha").IsRequired();
        builder.Property(x => x.HorHoraInicio).HasColumnName("hor_hora_inicio").IsRequired();
        builder.Property(x => x.HorHoraFin).HasColumnName("hor_hora_fin").IsRequired();
        builder.Property(x => x.HorCuposDisponibles).HasColumnName("hor_cupos_disponibles").IsRequired();

        builder.Property(x => x.HorFechaIngreso).HasColumnName("hor_fecha_ingreso").IsRequired();
        builder.Property(x => x.HorUsuarioIngreso).HasColumnName("hor_usuario_ingreso").HasMaxLength(100).IsRequired();
        builder.Property(x => x.HorIpIngreso).HasColumnName("hor_ip_ingreso").HasMaxLength(45).IsRequired();

        builder.Property(x => x.HorFechaMod).HasColumnName("hor_fecha_mod");
        builder.Property(x => x.HorUsuarioMod).HasColumnName("hor_usuario_mod").HasMaxLength(100);
        builder.Property(x => x.HorIpMod).HasColumnName("hor_ip_mod").HasMaxLength(45);

        builder.Property(x => x.HorFechaEliminacion).HasColumnName("hor_fecha_eliminacion");
        builder.Property(x => x.HorUsuarioEliminacion).HasColumnName("hor_usuario_eliminacion").HasMaxLength(100);
        builder.Property(x => x.HorIpEliminacion).HasColumnName("hor_ip_eliminacion").HasMaxLength(45);

        builder.Property(x => x.HorEstado).HasColumnName("hor_estado").HasMaxLength(1).IsRequired();

        builder.HasIndex(x => x.HorGuid).IsUnique();

        builder.HasOne(x => x.Ticket)
            .WithMany()
            .HasForeignKey(x => x.TckId);
    }
}