using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){
            CreateMap<Cargo,CargoDto>().ReverseMap();
            CreateMap<Cliente,ClienteDto>().ReverseMap();
            CreateMap<Color,ColorDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<DetalleOrden,DetalleOrdenDto>().ReverseMap();
            CreateMap<DetalleVenta,DetalleVentaDto>().ReverseMap();
            CreateMap<Empleado,EmpleadoDto>().ReverseMap();
            CreateMap<Empresa,EmpresaDto>().ReverseMap();
            CreateMap<Estado,EstadoDto>().ReverseMap();
            CreateMap<FormaPago,FormaPagoDto>().ReverseMap();
            CreateMap<Genero,GeneroDto>().ReverseMap();
            CreateMap<Insumo,InsumoDto>().ReverseMap();
            CreateMap<Inventario,InventarioDto>().ReverseMap();
            CreateMap<Municipio,MunicipioDto>().ReverseMap();
            CreateMap<Orden,OrdenDto>().ReverseMap();
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Prenda,PrendaDto>().ReverseMap();
            CreateMap<Proveedor,ProveedorDto>().ReverseMap();
            CreateMap<Talla,TallaDto>().ReverseMap();
            CreateMap<TipoEstado,TipoEstadoDto>().ReverseMap();
            CreateMap<TipoPersona,TipoPersonaDto>().ReverseMap();
            CreateMap<TipoProteccion,TipoProteccionDto>().ReverseMap();
            CreateMap<Venta,VentaDto>().ReverseMap();
            CreateMap<InsumoPrenda,InsumoPrendaDto>().ReverseMap();
            CreateMap<InsumoProveedor,InsumoProveedorDto>().ReverseMap();
            CreateMap<Orden,OrdenCTDto>().ReverseMap();
            CreateMap<Cliente,ClienteCTDto>().ReverseMap();
            CreateMap<DetalleOrden,DetalleOrdenPrendaDto>().ReverseMap();
            CreateMap<Estado,EstadoCTDto>().ReverseMap();
            CreateMap<VentaEmpleadoDto,Venta>().ReverseMap();
            CreateMap<InventarioTalla,InventarioTallaDto>().ReverseMap();
        }
    }
}