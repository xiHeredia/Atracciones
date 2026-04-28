using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class IdiomaAtraccionConfiguration : IEntityTypeConfiguration<IdiomaAtraccionEntity>
{
    public void Configure(EntityTypeBuilder<IdiomaAtraccionEntity> builder)
    {
        builder.ToTable("idioma_atraccion");

        builder.HasKey(x => new { x.IdId, x.AtId });

        builder.Property(x => x.IdId)
            .HasColumnName("id_id");

        builder.Property(x => x.AtId)
            .HasColumnName("at_id");

        builder.Property(x => x.IaFechaIngreso)
            .HasColumnName("ia_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.IaUsuarioIngreso)
            .HasColumnName("ia_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IaFechaEliminacion)
            .HasColumnName("ia_fecha_eliminacion");

        builder.Property(x => x.IaUsuarioEliminacion)
            .HasColumnName("ia_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.IaEstado)
            .HasColumnName("ia_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasOne(x => x.Atraccion)
            .WithMany(x => x.IdiomasAtraccion)
            .HasForeignKey(x => x.AtId);

        builder.HasOne(x => x.Idioma)
            .WithMany(x => x.IdiomasAtraccion)
            .HasForeignKey(x => x.IdId);
    }
}