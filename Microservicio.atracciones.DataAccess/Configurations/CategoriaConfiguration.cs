using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
    {
        builder.ToTable("categoria");

        builder.HasKey(x => x.CatId);
        builder.Property(x => x.CatId)
            .HasColumnName("cat_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CatGuid)
            .HasColumnName("cat_guid")
            .IsRequired();

        builder.Property(x => x.CatParentId)
            .HasColumnName("cat_parent_id");

        builder.Property(x => x.CatNombre)
            .HasColumnName("cat_nombre")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CatFechaIngreso)
            .HasColumnName("cat_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.CatUsuarioIngreso)
            .HasColumnName("cat_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CatIpIngreso)
            .HasColumnName("cat_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.CatFechaMod)
            .HasColumnName("cat_fecha_mod");

        builder.Property(x => x.CatUsuarioMod)
            .HasColumnName("cat_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.CatIpMod)
            .HasColumnName("cat_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.CatFechaEliminacion)
            .HasColumnName("cat_fecha_eliminacion");

        builder.Property(x => x.CatUsuarioEliminacion)
            .HasColumnName("cat_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.CatIpEliminacion)
            .HasColumnName("cat_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.CatEstado)
            .HasColumnName("cat_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.CatGuid).IsUnique();

        builder.HasOne(x => x.CategoriaPadre)
            .WithMany(x => x.Subcategorias)
            .HasForeignKey(x => x.CatParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}