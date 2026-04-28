using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Configurations;

public class AtraccionConfiguration : IEntityTypeConfiguration<AtraccionEntity>
{
    public void Configure(EntityTypeBuilder<AtraccionEntity> builder)
    {
        builder.ToTable("atraccion");

        builder.HasKey(x => x.AtId);
        builder.Property(x => x.AtId)
            .HasColumnName("at_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.AtGuid)
            .HasColumnName("at_guid")
            .IsRequired();

        builder.Property(x => x.DesId)
            .HasColumnName("des_id")
            .IsRequired();

        builder.Property(x => x.AtNumEstablecimiento)
            .HasColumnName("at_num_establecimiento")
            .HasMaxLength(30);

        builder.Property(x => x.AtNombre)
            .HasColumnName("at_nombre")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.AtDescripcion)
            .HasColumnName("at_descripcion")
            .HasMaxLength(2000);

        builder.Property(x => x.AtTotalResenias)
            .HasColumnName("at_total_resenias")
            .IsRequired();

        builder.Property(x => x.AtDireccion)
            .HasColumnName("at_direccion")
            .HasMaxLength(300);

        builder.Property(x => x.AtDuracionMinutos)
            .HasColumnName("at_duracion_minutos");

        builder.Property(x => x.AtPuntoEncuentro)
            .HasColumnName("at_punto_encuentro")
            .HasMaxLength(300);

        builder.Property(x => x.AtPrecioReferencia)
            .HasColumnName("at_precio_referencia")
            .HasPrecision(10, 2);

        builder.Property(x => x.AtIncluyeAcompaniante)
            .HasColumnName("at_incluye_acompaniante")
            .IsRequired();

        builder.Property(x => x.AtIncluyeTransporte)
            .HasColumnName("at_incluye_transporte")
            .IsRequired();

        builder.Property(x => x.AtDisponible)
            .HasColumnName("at_disponible")
            .IsRequired();

        builder.Property(x => x.AtFechaIngreso)
            .HasColumnName("at_fecha_ingreso")
            .IsRequired();

        builder.Property(x => x.AtUsuarioIngreso)
            .HasColumnName("at_usuario_ingreso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.AtIpIngreso)
            .HasColumnName("at_ip_ingreso")
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(x => x.AtFechaMod)
            .HasColumnName("at_fecha_mod");

        builder.Property(x => x.AtUsuarioMod)
            .HasColumnName("at_usuario_mod")
            .HasMaxLength(100);

        builder.Property(x => x.AtIpMod)
            .HasColumnName("at_ip_mod")
            .HasMaxLength(45);

        builder.Property(x => x.AtFechaEliminacion)
            .HasColumnName("at_fecha_eliminacion");

        builder.Property(x => x.AtUsuarioEliminacion)
            .HasColumnName("at_usuario_eliminacion")
            .HasMaxLength(100);

        builder.Property(x => x.AtIpEliminacion)
            .HasColumnName("at_ip_eliminacion")
            .HasMaxLength(45);

        builder.Property(x => x.AtEstado)
            .HasColumnName("at_estado")
            .HasMaxLength(1)
            .IsRequired();

        builder.HasIndex(x => x.AtGuid).IsUnique();

        builder.HasOne(x => x.Destino)
            .WithMany(x => x.Atracciones)
            .HasForeignKey(x => x.DesId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}