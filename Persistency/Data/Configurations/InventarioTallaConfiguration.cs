using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class InventarioTallaConfiguration : IEntityTypeConfiguration<InventarioTalla>
    {
        public void Configure(EntityTypeBuilder<InventarioTalla> builder)
        {
            builder.ToTable("InventarioTalla");
            builder.HasKey(t => new { t.InventarioId, t.TallaId });
            builder.Property(p=>p.Cantidad).HasColumnName("Cantidad").HasColumnType("int").IsRequired();
        }
    }
}