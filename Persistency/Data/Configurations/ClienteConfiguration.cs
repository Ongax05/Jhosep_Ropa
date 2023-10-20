using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(p=>p.CodigoCliente).HasColumnName("CodigoCliente").HasMaxLength(250).IsRequired();
            builder.HasOne(p=>p.TipoPersona).WithMany(p=>p.Clientes).HasForeignKey(p=>p.TipoPersonaId);
            builder.HasOne(p=>p.Municipio).WithMany(p=>p.Clientes).HasForeignKey(p=>p.MunicipioId);
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.FechaRegistro).HasColumnName("FechaRegistro").HasColumnType("datetime").IsRequired();
            

        }
    }
}