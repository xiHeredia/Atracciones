using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class IncluyeConfiguration : IEntityTypeConfiguration<IncluyeEntity>
{
    public void Configure(EntityTypeBuilder<IncluyeEntity> builder)
    {
        builder.ToTable("incluye");

        builder.HasKey(x => x.IncId);

        builder.Property(x => x.IncId)
            .HasColumnName("inc_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IncGuid)
            .HasColumnName("inc_guid")
            .IsRequired();

        builder.Property(x => x.IncDescripcion)
            .HasColumnName("inc_descripcion")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.IncEstado)
            .HasColumnName("inc_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.IncGuid).IsUnique();
    }
}