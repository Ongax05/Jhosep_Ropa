using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(p=>p.Nit).HasColumnName("Nit").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.RazonSocial).HasColumnName("RazonSocial").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.RepresentanteLegal).HasColumnName("RepresentanteLegal").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.FechaCreacion).HasColumnName("FechaCreacion").HasColumnType("datetime").IsRequired();
            builder.HasOne(p=>p.Municipio).WithMany(p=>p.Empresas).HasForeignKey(p=>p.MunicipioId);
        }
    }
}