using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistency.Data.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Domain.Entities.Color>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Color> builder)
        {
            builder.ToTable("Color");
            builder.Property(p=>p.Descripcion).HasColumnName("Descripcion").HasMaxLength(250).IsRequired();
        }
    }
}