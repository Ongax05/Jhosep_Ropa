using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.ToTable("Prenda");
            builder.Property(p=>p.CodigoPrenda).HasColumnName("CodigoPrenda").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.ValorUnitarioCOP).HasColumnName("ValorUnitarioCOP").HasColumnType("double").IsRequired();
            builder.Property(p=>p.ValorUnitarioUSD).HasColumnName("ValorUnitarioUSD").HasColumnType("double").IsRequired();
            builder.HasOne(p=>p.Estado).WithMany(p=>p.Prendas).HasForeignKey(p=>p.EstadoId);
            builder.HasOne(p=>p.TipoProteccion).WithMany(p=>p.Prendas).HasForeignKey(p=>p.TipoProteccionId);
            builder.HasOne(p=>p.Genero).WithMany(p=>p.Prendas).HasForeignKey(p=>p.GeneroId);
        }
    }
}