using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<RolEntity>
{
    public void Configure(EntityTypeBuilder<RolEntity> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(x => x.RolId);
        builder.Property(x => x.RolId)
            .HasColumnName("rol_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.RolGuid)
            .HasColumnName("rol_guid")
            .IsRequired();

        builder.Property(x => x.RolDescripcion)
            .HasColumnName("rol_descripcion")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.RolFechaIngreso)
            .HasColumnName("rol_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.RolUsuarioIngreso)
            .HasColumnName("rol_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.RolIpIngreso)
            .HasColumnName("rol_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.RolFechaEliminacion)
            .HasColumnName("rol_fecha_eliminacion");

        builder.Property(x => x.RolUsuarioEliminacion)
            .HasColumnName("rol_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.RolIpEliminacion)
            .HasColumnName("rol_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.RolEstado)
            .HasColumnName("rol_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.RolGuid).IsUnique();
    }
}