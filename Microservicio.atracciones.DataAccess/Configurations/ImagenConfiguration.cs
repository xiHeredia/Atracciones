using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class ImagenConfiguration : IEntityTypeConfiguration<ImagenEntity>
{
    public void Configure(EntityTypeBuilder<ImagenEntity> builder)
    {
        builder.ToTable("imagen");

        builder.HasKey(x => x.ImgId);

        builder.Property(x => x.ImgId)
            .HasColumnName("img_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ImgGuid)
            .HasColumnName("img_guid")
            .IsRequired();

        builder.Property(x => x.ImgUrl)
            .HasColumnName("img_url")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ImgDescripcion)
            .HasColumnName("img_descripcion")
            .HasMaxLength(200);

        builder.Property(x => x.ImgFechaIngreso)
            .HasColumnName("img_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.ImgUsuarioIngreso)
            .HasColumnName("img_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ImgIpIngreso)
            .HasColumnName("img_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.ImgFechaMod)
            .HasColumnName("img_fecha_mod");

        builder.Property(x => x.ImgUsuarioMod)
            .HasColumnName("img_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.ImgIpMod)
            .HasColumnName("img_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.ImgFechaEliminacion)
            .HasColumnName("img_fecha_eliminacion");

        builder.Property(x => x.ImgUsuarioEliminacion)
            .HasColumnName("img_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.ImgIpEliminacion)
            .HasColumnName("img_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.ImgEstado)
            .HasColumnName("img_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.ImgGuid).IsUnique();
    }
}