using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(100).IsRequired();
            builder.HasOne(p=>p.Pais).WithMany(p=>p.Departamentos).HasForeignKey(p=>p.PaisId);
        }
    }
}