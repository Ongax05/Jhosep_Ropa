using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");
            builder.Property(p=>p.NitProveedor).HasColumnName("NitProveedor").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(250).IsRequired();
            builder.HasOne(p=>p.TipoPersona).WithMany(p=>p.Proveedores).HasForeignKey(p=>p.TipoPersonaId);
            builder.HasOne(p=>p.Municipio).WithMany(p=>p.Proveedores).HasForeignKey(p=>p.MunicipioId);
        }
    }
}