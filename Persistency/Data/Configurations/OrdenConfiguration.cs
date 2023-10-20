using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden");
            builder.Property(p=>p.Fecha).HasColumnName("Fecha").HasColumnType("datetime").IsRequired();
            builder.HasOne(p=>p.Empleado).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.EmpleadoId);
            builder.HasOne(p=>p.Cliente).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.ClienteId);
            builder.HasOne(p=>p.Estado).WithMany(p=>p.Ordenes).HasForeignKey(p=>p.EstadoId);
        }
    }
}