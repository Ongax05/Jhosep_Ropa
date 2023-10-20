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
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FormaPago> FormasPagos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<TipoEstado> TiposEstados { get; set; }
        public DbSet<TipoPersona> TiposPersonas { get; set; }
        public DbSet<TipoProteccion> TiposProtecciones { get; set; }
        public DbSet<Venta> Ventas { get; set; }
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
