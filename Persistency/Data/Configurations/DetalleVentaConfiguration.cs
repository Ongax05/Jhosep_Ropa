using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.Property(p=>p.Cantidad).HasColumnName("Cantidad").HasColumnType("int").IsRequired();
            builder.Property(p=>p.ValorUnitario).HasColumnName("ValorUnitario").HasColumnType("double").IsRequired();
            builder.HasOne(p=>p.Venta).WithMany(p=>p.DetallesVentas).HasForeignKey(p=>p.VentaId);
            builder.HasOne(p=>p.Inventario).WithMany(p=>p.DetallesVentas).HasForeignKey(p=>p.InventarioId);
            builder.HasOne(p=>p.Talla).WithMany(p=>p.DetallesVentas).HasForeignKey(p=>p.TallaId);
        }
    }
}