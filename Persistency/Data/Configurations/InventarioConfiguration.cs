using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");
            builder.HasOne(p=>p.Prenda).WithMany(p=>p.Inventarios).HasForeignKey(p=>p.PrendaId);
            builder.Property(p=>p.CodigoInventario).HasColumnName("CodigoInventario").HasMaxLength(250).IsRequired();
        }
    }
}