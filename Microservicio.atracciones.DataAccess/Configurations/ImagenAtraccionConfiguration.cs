using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class ImagenAtraccionConfiguration : IEntityTypeConfiguration<ImagenAtraccionEntity>
{
    public void Configure(EntityTypeBuilder<ImagenAtraccionEntity> builder)
    {
        builder.ToTable("imagen_atraccion");

        builder.HasKey(x => new { x.ImgId, x.AtId });

        builder.Property(x => x.ImgId)
            .HasColumnName("img_id");

        builder.Property(x => x.AtId)
            .HasColumnName("at_id");

        builder.Property(x => x.ImaFechaIngreso)
            .HasColumnName("ima_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.ImaUsuarioIngreso)
            .HasColumnName("ima_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ImaFechaEliminacion)
            .HasColumnName("ima_fecha_eliminacion");

        builder.Property(x => x.ImaUsuarioEliminacion)
            .HasColumnName("ima_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.ImaEstado)
            .HasColumnName("ima_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasOne(x => x.Atraccion)
            .WithMany(x => x.ImagenesAtraccion)
            .HasForeignKey(x => x.AtId);

        builder.HasOne(x => x.Imagen)
            .WithMany(x => x.ImagenesAtraccion)
            .HasForeignKey(x => x.ImgId);
    }
}