using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistency;

public class ApiDbContext : DbContext
{
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Cliente>().HasAlternateKey(p=>p.CodigoCliente);
            modelBuilder.Entity<Insumo>().HasAlternateKey(p=>p.Nombre);
            modelBuilder.Entity<Prenda>().HasAlternateKey(p=>p.CodigoPrenda);
            modelBuilder.Entity<Empresa>().HasAlternateKey(p=>p.Nit);
            modelBuilder.Entity<Proveedor>().HasAlternateKey(p=>p.NitProveedor);
            modelBuilder.Entity<Empleado>().HasAlternateKey(p=>p.CodigoEmpleado);
            modelBuilder.Entity<Inventario>().HasAlternateKey(p=>p.CodigoInventario);
        }

}
