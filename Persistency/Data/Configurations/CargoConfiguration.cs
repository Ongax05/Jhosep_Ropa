using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            builder.Property(p=>p.Descripcion).HasColumnName("Descripcion").HasMaxLength(150).IsRequired();
            builder.Property(p=>p.SueldoBase).HasColumnName("SueldoBase").HasColumnType("double").IsRequired();
        }
    }
}