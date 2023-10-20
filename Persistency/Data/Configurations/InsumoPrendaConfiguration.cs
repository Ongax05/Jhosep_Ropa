using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class InsumoPrendaConfiguration : IEntityTypeConfiguration<InsumoPrenda>
    {
        public void Configure(EntityTypeBuilder<InsumoPrenda> builder)
        {
            builder.ToTable("InsumoPrenda");
            builder.Property(p=>p.Cantidad).HasColumnName("Cantidad").HasColumnType("int").IsRequired();
            builder.HasKey(t => new { t.InsumoId, t.PrendaId });
        }
    }
}