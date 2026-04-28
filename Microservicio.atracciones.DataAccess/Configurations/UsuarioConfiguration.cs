using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(x => x.UsuId);
        builder.Property(x => x.UsuId)
            .HasColumnName("usu_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UsuGuid)
            .HasColumnName("usu_guid")
            .IsRequired();

        builder.Property(x => x.UsuLogin)
            .HasColumnName("usu_login")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UsuPasswordHash)
            .HasColumnName("usu_password_hash")
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.UsuFechaRegistro)
            .HasColumnName("usu_fecha_registro")
            .IsRequired();

        builder.Property(x => x.UsuUsuarioRegistro)
            .HasColumnName("usu_usuario_registro")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.UsuIpRegistro)
            .HasColumnName("usu_ip_registro")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.UsuFechaMod)
            .HasColumnName("usu_fecha_mod");

        builder.Property(x => x.UsuUsuarioMod)
            .HasColumnName("usu_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.UsuIpMod)
            .HasColumnName("usu_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.UsuFechaEliminacion)
            .HasColumnName("usu_fecha_eliminacion");

        builder.Property(x => x.UsuUsuarioEliminacion)
            .HasColumnName("usu_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.UsuIpEliminacion)
            .HasColumnName("usu_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.UsuEstado)
            .HasColumnName("usu_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.UsuGuid).IsUnique();
        builder.HasIndex(x => x.UsuLogin).IsUnique();
    }
}