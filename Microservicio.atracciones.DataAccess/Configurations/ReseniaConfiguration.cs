using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class ReseniaConfiguration : IEntityTypeConfiguration<ReseniaEntity>
{
    public void Configure(EntityTypeBuilder<ReseniaEntity> builder)
    {
        builder.ToTable("resenia");

        builder.HasKey(x => x.RsnId);

        builder.Property(x => x.RsnId).HasColumnName("rsn_id").ValueGeneratedOnAdd();
        builder.Property(x => x.RsnGuid).HasColumnName("rsn_guid").IsRequired();

        builder.Property(x => x.AtId).HasColumnName("at_id").IsRequired();
        builder.Property(x => x.RevId).HasColumnName("rev_id").IsRequired();

        builder.Property(x => x.RsnComentario).HasColumnName("rsn_comentario").HasMaxLength(1000).IsRequired();
        builder.Property(x => x.RsnRating).HasColumnName("rsn_rating").IsRequired();

        builder.Property(x => x.RsnFechaCreacion).HasColumnName("rsn_fecha_creacion").IsRequired();
        builder.Property(x => x.RsnUsuarioCreacion).HasColumnName("rsn_usuario_creacion").HasMaxLength(100).IsRequired();
        builder.Property(x => x.RsnIpCreacion).HasColumnName("rsn_ip_creacion").HasMaxLength(45).IsRequired();

        builder.Property(x => x.RsnFechaMod).HasColumnName("rsn_fecha_mod");
        builder.Property(x => x.RsnUsuarioMod).HasColumnName("rsn_usuario_mod").HasMaxLength(100);
        builder.Property(x => x.RsnIpMod).HasColumnName("rsn_ip_mod").HasMaxLength(45);

        builder.Property(x => x.RsnFechaEliminacion).HasColumnName("rsn_fecha_eliminacion");
        builder.Property(x => x.RsnUsuarioEliminacion).HasColumnName("rsn_usuario_eliminacion").HasMaxLength(100);
        builder.Property(x => x.RsnIpEliminacion).HasColumnName("rsn_ip_eliminacion").HasMaxLength(45);

        builder.Property(x => x.RsnEstado).HasColumnName("rsn_estado").HasMaxLength(1).IsRequired();

        builder.HasIndex(x => x.RsnGuid).IsUnique();

        builder.HasOne(x => x.Atraccion)
            .WithMany()
            .HasForeignKey(x => x.AtId);

        builder.HasOne(x => x.Reserva)
            .WithMany()
            .HasForeignKey(x => x.RevId);
    }
}