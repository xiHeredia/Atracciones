using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class CategoriaAtraccionConfiguration : IEntityTypeConfiguration<CategoriaAtraccionEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaAtraccionEntity> builder)
    {
        builder.ToTable("categoria_atraccion");

        builder.HasKey(x => new { x.CatId, x.AtId });

        builder.Property(x => x.CatId)
            .HasColumnName("cat_id");

        builder.Property(x => x.AtId)
            .HasColumnName("at_id");

        builder.Property(x => x.CaFechaIngreso)
            .HasColumnName("ca_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.CaUsuarioIngreso)
            .HasColumnName("ca_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.CaFechaEliminacion)
            .HasColumnName("ca_fecha_eliminacion");

        builder.Property(x => x.CaUsuarioEliminacion)
            .HasColumnName("ca_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.CaEstado)
            .HasColumnName("ca_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.CategoriasAtraccion)
            .HasForeignKey(x => x.CatId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Atraccion)
            .WithMany(x => x.CategoriasAtraccion)
            .HasForeignKey(x => x.AtId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
