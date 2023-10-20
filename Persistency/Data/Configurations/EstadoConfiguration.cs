using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");
            builder.Property(p=>p.Descripcion).HasColumnName("Descripcion").HasMaxLength(250).IsRequired();
            builder.HasOne(p=>p.TipoEstado).WithMany(p=>p.Estados).HasForeignKey(p=>p.TipoEstadoId);
        }
    }
}