using Aplication.Repository;
using Domain.Interfaces;
using Persistency;
namespace Aplication.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
    private IVenta _Ventas;
    public IVenta Ventas
    {
        get
        {
            _Ventas ??= new VentaRepository(_context);
            return _Ventas;
        }
    }
    private ITipoProteccion _TiposProtecciones;
    public ITipoProteccion TiposProtecciones
    {
        get
        {
            _TiposProtecciones ??= new TipoProteccionRepository(_context);
            return _TiposProtecciones;
        }
    }
    private ITipoPersona _TiposPersonas;
    public ITipoPersona TiposPersonas
    {
        get
        {
            _TiposPersonas ??= new TipoPersonaRepository(_context);
            return _TiposPersonas;
        }
    }
    private ITipoEstado _TiposEstados;
    public ITipoEstado TiposEstados
    {
        get
        {
            _TiposEstados ??= new TipoEstadoRepository(_context);
            return _TiposEstados;
        }
    }
    private ITalla _Tallas;
    public ITalla Tallas
    {
        get
        {
            _Tallas ??= new TallaRepository(_context);
            return _Tallas;
        }
    }
    private IProveedor _Proveedores;
    public IProveedor Proveedores
    {
        get
        {
            _Proveedores ??= new ProveedorRepository(_context);
            return _Proveedores;
        }
    }
    private IPrenda _Prendas;
    public IPrenda Prendas
    {
        get
        {
            _Prendas ??= new PrendaRepository(_context);
            return _Prendas;
        }
    }
    private IPais _Paises;
    public IPais Paises
    {
        get
        {
            _Paises ??= new PaisRepository(_context);
            return _Paises;
        }
    }
    private IOrden _Ordenes;
    public IOrden Ordenes
    {
        get
        {
            _Ordenes ??= new OrdenRepository(_context);
            return _Ordenes;
        }
    }
    private IMunicipio _Municipios;
    public IMunicipio Municipios
    {
        get
        {
            _Municipios ??= new MunicipioRepository(_context);
            return _Municipios;
        }
    }
    private IInventario _Inventarios;
    public IInventario Inventarios
    {
        get
        {
            _Inventarios ??= new InventarioRepository(_context);
            return _Inventarios;
        }
    }
    private IInsumo _Insumos;
    public IInsumo Insumos
    {
        get
        {
            _Insumos ??= new InsumoRepository(_context);
            return _Insumos;
        }
    }
    private IGenero _Generos;
    public IGenero Generos
    {
        get
        {
            _Generos ??= new GeneroRepository(_context);
            return _Generos;
        }
    }
    private IFormaPago _FormasPagos;
    public IFormaPago FormasPagos
    {
        get
        {
            _FormasPagos ??= new FormaPagoRepository(_context);
            return _FormasPagos;
        }
    }
    private IEstado _Estados;
    public IEstado Estados
    {
        get
        {
            _Estados ??= new EstadoRepository(_context);
            return _Estados;
        }
    }
    private IEmpresa _Empresas;
    public IEmpresa Empresas
    {
        get
        {
            _Empresas ??= new EmpresaRepository(_context);
            return _Empresas;
        }
    }
    private IEmpleado _Empleados;
    public IEmpleado Empleados
    {
        get
        {
            _Empleados ??= new EmpleadoRepository(_context);
            return _Empleados;
        }
    }
    private IDetalleVenta _DetallesVentas;
    public IDetalleVenta DetallesVentas
    {
        get
        {
            _DetallesVentas ??= new DetalleVentaRepository(_context);
            return _DetallesVentas;
        }
    }
    private IDetalleOrden _DetallesOrdenes;
    public IDetalleOrden DetallesOrdenes
    {
        get
        {
            _DetallesOrdenes ??= new DetalleOrdenRepository(_context);
            return _DetallesOrdenes;
        }
    }
    private IDepartamento _Departamentos;
    public IDepartamento Departamentos
    {
        get
        {
            _Departamentos ??= new DepartamentoRepository(_context);
            return _Departamentos;
        }
    }
    private IColor _Colores;
    public IColor Colores
    {
        get
        {
            _Colores ??= new ColorRepository(_context);
            return _Colores;
        }
    }
    private ICliente _Clientes;
    public ICliente Clientes
    {
        get
        {
            _Clientes ??= new ClienteRepository(_context);
            return _Clientes;
        }
    }
    private ICargo _Cargos;
    public ICargo Cargos
    {
        get
        {
            _Cargos ??= new CargoRepository(_context);
            return _Cargos;
        }
    }

    private IInsumoProveedor _InsumosProveedores;
    public IInsumoProveedor InsumosProveedores
    {
        get
        {
            _InsumosProveedores ??= new InsumoProveedorRepository(_context);
            return _InsumosProveedores;
        }
    }
    private IInsumoPrenda _InsumosPrendas;
    public IInsumoPrenda InsumosPrendas
    {
        get
        {
            _InsumosPrendas ??= new InsumoPrendaRepository(_context);
            return _InsumosPrendas;
        }
    }
    private IInventarioTalla _InventariosTallas;
    public IInventarioTalla InventariosTallas
    {
        get
        {
            _InventariosTallas ??= new InventarioTallaRepository(_context);
            return _InventariosTallas;
        }
    }
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
