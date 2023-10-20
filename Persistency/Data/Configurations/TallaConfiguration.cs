using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class TallaConfiguration : IEntityTypeConfiguration<Talla>
    {
        public void Configure(EntityTypeBuilder<Talla> builder)
        {
            builder.ToTable("Talla");
            builder.Property(p=>p.Descripcion).HasColumnName("Descripcion").HasMaxLength(250).IsRequired();
        }
    }
}