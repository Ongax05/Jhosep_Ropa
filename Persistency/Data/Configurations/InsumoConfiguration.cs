using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.ToTable("Insumo");
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.ValorUnitario).HasColumnName("ValorUnitario").HasColumnType("double").IsRequired();
            builder.Property(p=>p.StockMinimo).HasColumnName("StockMinimo").HasColumnType("int").IsRequired();
            builder.Property(p=>p.StockMaximo).HasColumnName("StockMaximo").HasColumnType("int").IsRequired();
        }
    }
}