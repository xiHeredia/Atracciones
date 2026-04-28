using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class IdiomaConfiguration : IEntityTypeConfiguration<IdiomaEntity>
{
    public void Configure(EntityTypeBuilder<IdiomaEntity> builder)
    {
        builder.ToTable("idioma");

        builder.HasKey(x => x.IdiId);

        builder.Property(x => x.IdiId)
            .HasColumnName("idi_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdiGuid)
            .HasColumnName("idi_guid")
            .IsRequired();

        builder.Property(x => x.IdiDescripcion)
            .HasColumnName("idi_descripcion")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.IdiFechaIngreso)
            .HasColumnName("idi_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.IdUsuarioIngreso)
            .HasColumnName("id_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IdiIpIngreso)
            .HasColumnName("idi_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.IdiFechaMod)
            .HasColumnName("idi_fecha_mod");

        builder.Property(x => x.IdUsuarioMod)
            .HasColumnName("id_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.IdiIpMod)
            .HasColumnName("idi_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.IdiFechaEliminacion)
            .HasColumnName("idi_fecha_eliminacion");

        builder.Property(x => x.IdUsuarioEliminacion)
            .HasColumnName("id_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.IdiIpEliminacion)
            .HasColumnName("idi_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.IdiEstado)
            .HasColumnName("idi_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.IdiGuid).IsUnique();
    }
}