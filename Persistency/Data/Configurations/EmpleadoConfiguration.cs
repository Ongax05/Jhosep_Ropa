using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.Property(p=>p.CodigoEmpleado).HasColumnName("CodigoEmpleado").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.Nombre).HasColumnName("Nombre").HasMaxLength(250).IsRequired();
            builder.Property(p=>p.FechaIngreso).HasColumnName("FechaIngreso").HasColumnType("datetime").IsRequired();
            builder.HasOne(p=>p.Municipio).WithMany(p=>p.Empleados).HasForeignKey(p=>p.MunicipioId);
            builder.HasOne(p=>p.Cargo).WithMany(p=>p.Empleados).HasForeignKey(p=>p.CargoId);
        }
    }
}