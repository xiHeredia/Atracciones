using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class DatosFacturacionConfiguration : IEntityTypeConfiguration<DatosFacturacionEntity>
{
    public void Configure(EntityTypeBuilder<DatosFacturacionEntity> builder)
    {
        builder.ToTable("datos_facturacion");

        builder.HasKey(x => x.DfacId);

        builder.Property(x => x.DfacId).HasColumnName("dfac_id").ValueGeneratedOnAdd();
        builder.Property(x => x.DfacGuid).HasColumnName("dfac_guid").IsRequired();

        builder.Property(x => x.FacId).HasColumnName("fac_id").IsRequired();

        builder.Property(x => x.DfacNombre).HasColumnName("dfac_nombre").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DfacApellido).HasColumnName("dfac_apellido").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DfacCorreo).HasColumnName("dfac_correo").HasMaxLength(150).IsRequired();
        builder.Property(x => x.DfacTelefono).HasColumnName("dfac_telefono").HasMaxLength(20);

        builder.HasIndex(x => x.DfacGuid).IsUnique();

        builder.HasOne(x => x.Factura)
            .WithMany()
            .HasForeignKey(x => x.FacId);
    }
}
