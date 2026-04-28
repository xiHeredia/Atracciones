using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class AtraccionIncluyeConfiguration : IEntityTypeConfiguration<AtraccionIncluyeEntity>
{
    public void Configure(EntityTypeBuilder<AtraccionIncluyeEntity> builder)
    {
        builder.ToTable("atraccion_incluye");

        builder.HasKey(x => new { x.IncId, x.AtId });

        builder.Property(x => x.IncId)
            .HasColumnName("inc_id");

        builder.Property(x => x.AtId)
            .HasColumnName("at_id");

        builder.Property(x => x.AiFechaIngreso)
            .HasColumnName("ai_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.AiUsuarioIngreso)
            .HasColumnName("ai_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.AiFechaEliminacion)
            .HasColumnName("ai_fecha_eliminacion");

        builder.Property(x => x.AiUsuarioEliminacion)
            .HasColumnName("ai_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.AiEstado)
            .HasColumnName("ai_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasOne(x => x.Atraccion)
            .WithMany(x => x.AtraccionesIncluye)
            .HasForeignKey(x => x.AtId);

        builder.HasOne(x => x.Incluye)
            .WithMany(x => x.AtraccionesIncluye)
            .HasForeignKey(x => x.IncId);
    }
}