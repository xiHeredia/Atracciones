using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRolEntity>
{
    public void Configure(EntityTypeBuilder<UsuarioRolEntity> builder)
    {
        builder.ToTable("usuarioxroles");

        builder.HasKey(x => x.UsuRolId);

        builder.Property(x => x.UsuRolId)
            .HasColumnName("usu_rol_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UsuId)
            .HasColumnName("usu_id")
            .IsRequired();

        builder.Property(x => x.RolId)
            .HasColumnName("rol_id")
            .IsRequired();

        builder.Property(x => x.UsuRolEstado)
            .HasColumnName("usu_rol_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => new { x.UsuId, x.RolId }).IsUnique();

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.UsuarioRoles)
            .HasForeignKey(x => x.UsuId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Rol)
            .WithMany(x => x.UsuarioRoles)
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}