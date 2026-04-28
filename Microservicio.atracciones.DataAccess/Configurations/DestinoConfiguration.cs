using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class DestinoConfiguration : IEntityTypeConfiguration<DestinoEntity>
{
    public void Configure(EntityTypeBuilder<DestinoEntity> builder)
    {
        builder.ToTable("destino");

        builder.HasKey(x => x.DesId);
        builder.Property(x => x.DesId)
            .HasColumnName("des_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DesGuid)
            .HasColumnName("des_guid")
            .IsRequired();

        builder.Property(x => x.DesNombre)
            .HasColumnName("des_nombre")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.DesPais)
            .HasColumnName("des_pais")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DesImagenUrl)
            .HasColumnName("des_imagen_url")
            .HasMaxLength(500);

        builder.Property(x => x.DesFechaIngreso)
            .HasColumnName("des_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.DesUsuarioIngreso)
            .HasColumnName("des_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DesIpIngreso)
            .HasColumnName("des_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.DesFechaMod)
            .HasColumnName("des_fecha_mod");

        builder.Property(x => x.DesUsuarioMod)
            .HasColumnName("des_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.DesIpMod)
            .HasColumnName("des_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.DesFechaEliminacion)
            .HasColumnName("des_fecha_eliminacion");

        builder.Property(x => x.DesUsuarioEliminacion)
            .HasColumnName("des_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.DesIpEliminacion)
            .HasColumnName("des_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.DesEstado)
            .HasColumnName("des_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.DesGuid).IsUnique();
    }
}