using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
    {
        public void Configure(EntityTypeBuilder<DetalleOrden> builder)
        {
            builder.ToTable("DetalleOrden");
            builder.Property(p=>p.CantidadProducida).HasColumnName("CantidadProducida").HasColumnType("double").IsRequired();
            builder.HasOne(p=>p.Orden).WithMany(p=>p.DetallesOrdenes).HasForeignKey(p=>p.OrdenId);
            builder.HasOne(p=>p.Prenda).WithMany(p=>p.DetallesOrdenes).HasForeignKey(p=>p.PrendaId);
            builder.HasOne(p=>p.Color).WithMany(p=>p.DetallesOrdenes).HasForeignKey(p=>p.ColorId);
            builder.HasOne(p=>p.Estado).WithMany(p=>p.DetallesOrdenes).HasForeignKey(p=>p.EstadoId);
        }
    }
}