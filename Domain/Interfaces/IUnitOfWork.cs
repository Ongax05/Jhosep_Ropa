namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IInventarioTalla InventariosTallas {get;}
    IInsumoPrenda InsumosPrendas {get;}
    IInsumoProveedor InsumosProveedores {get;}
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    ICargo Cargos { get; }
    ICliente Clientes { get; }
    IColor Colores { get; }
    IDepartamento Departamentos { get; }
    IDetalleOrden DetallesOrdenes { get; }
    IDetalleVenta DetallesVentas { get; }
    IEmpleado Empleados { get; }
    IEmpresa Empresas { get; }
    IEstado Estados { get; }
    IFormaPago FormasPagos { get; }
    IGenero Generos { get; }
    IInsumo Insumos { get; }
    IInventario Inventarios { get; }
    IMunicipio Municipios { get; }
    IOrden Ordenes { get; }
    IPais Paises { get; }
    IPrenda Prendas { get; }
    IProveedor Proveedores { get; }
    ITalla Tallas { get; }
    ITipoEstado TiposEstados { get; }
    ITipoPersona TiposPersonas { get; }
    ITipoProteccion TiposProtecciones { get; }
    IVenta Ventas { get; }
    Task<int> SaveAsync();
}
