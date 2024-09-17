using AutoMapper;
using API_AntonioWalls.Models_Instancia1;
using API_AntonioWalls.DTOsucursal1;
namespace API_AntonioWalls.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre Categoria y DTOCategoria
            CreateMap<Categoria, DTOCategoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOCategoria, Categoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre Cliente y DTOCliente
            CreateMap<Cliente, DTOCliente>()
            .ForMember(dest => dest.IdCliente, opt => opt.Condition(src => src.IdCliente != null))
            .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null))
            .ForMember(dest => dest.NomP, opt => opt.Condition(src => src.NomP != null))
            .ForMember(dest => dest.Calle, opt => opt.Condition(src => src.Calle != null))
            .ForMember(dest => dest.Num, opt => opt.Condition(src => src.Num != null))
            .ForMember(dest => dest.Col, opt => opt.Condition(src => src.Col != null))
            .ForMember(dest => dest.Ciudad, opt => opt.Condition(src => src.Ciudad != null))
            .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != null))
            .ForMember(dest => dest.Pais, opt => opt.Condition(src => src.Pais != null))
            .ForMember(dest => dest.Cp, opt => opt.Condition(src => src.Cp != null))
            .ForMember(dest => dest.Telefono, opt => opt.Condition(src => src.Telefono != null))
            .ForMember(dest => dest.Rfc, opt => opt.Condition(src => src.Rfc != null))
            .ForMember(dest => dest.Correo, opt => opt.Condition(src => src.Correo != null))
            .ForMember(dest => dest.FechaReg, opt => opt.Condition(src => src.FechaReg != null))
            .ForMember(dest => dest.ApP, opt => opt.Condition(src => src.ApP != null)) // Agrega esta línea para apP
            .ForMember(dest => dest.ApM, opt => opt.Condition(src => src.ApM != null)); // Agrega esta línea para apM

            CreateMap<DTOCliente, Cliente>()
            .ForMember(dest => dest.IdCliente, opt => opt.Condition(src => src.IdCliente != null))
            .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null))
            .ForMember(dest => dest.NomP, opt => opt.Condition(src => src.NomP != null))
            .ForMember(dest => dest.Calle, opt => opt.Condition(src => src.Calle != null))
            .ForMember(dest => dest.Num, opt => opt.Condition(src => src.Num != null))
            .ForMember(dest => dest.Col, opt => opt.Condition(src => src.Col != null))
            .ForMember(dest => dest.Ciudad, opt => opt.Condition(src => src.Ciudad != null))
            .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != null))
            .ForMember(dest => dest.Pais, opt => opt.Condition(src => src.Pais != null))
            .ForMember(dest => dest.Cp, opt => opt.Condition(src => src.Cp != null))
            .ForMember(dest => dest.Telefono, opt => opt.Condition(src => src.Telefono != null))
            .ForMember(dest => dest.Rfc, opt => opt.Condition(src => src.Rfc != null))
            .ForMember(dest => dest.Correo, opt => opt.Condition(src => src.Correo != null))
            .ForMember(dest => dest.FechaReg, opt => opt.Condition(src => src.FechaReg != null))
            .ForMember(dest => dest.ApP, opt => opt.Condition(src => src.ApP != null)) // Agrega esta línea para apP
            .ForMember(dest => dest.ApM, opt => opt.Condition(src => src.ApM != null)); // Agrega esta línea para apM

            // Mapeo entre Cocteleria y DTOCocteleria
            CreateMap <Cocteleria,DTOCocteleria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOCocteleria, Cocteleria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre DetVenta y DTODetVenta
            CreateMap <DetVenta, DTODetVenta>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap <DTODetVenta, DetVenta>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre Empleado y DTOEmpleado
            CreateMap <Empleado, DTOEmpleado>()

             .ForMember(dest => dest.IdEmpleado, opt => opt.Condition(src => src.IdEmpleado != null))
             .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null))
             .ForMember(dest => dest.NomP, opt => opt.Condition(src => src.NomP != null))
             .ForMember(dest => dest.ApP, opt => opt.Condition(src => src.ApP != null))
             .ForMember(dest => dest.ApM, opt => opt.Condition(src => src.ApM != null))
             .ForMember(dest => dest.Calle, opt => opt.Condition(src => src.Calle != null))
             .ForMember(dest => dest.Num, opt => opt.Condition(src => src.Num != null))
             .ForMember(dest => dest.Col, opt => opt.Condition(src => src.Col != null))
             .ForMember(dest => dest.Ciudad, opt => opt.Condition(src => src.Ciudad != null))
             .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != null))
             .ForMember(dest => dest.Pais, opt => opt.Condition(src => src.Pais != null))
             .ForMember(dest => dest.Cp, opt => opt.Condition(src => src.Cp != null))
             .ForMember(dest => dest.TelEmp, opt => opt.Condition(src => src.TelEmp != null))
             .ForMember(dest => dest.CorreoEmp, opt => opt.Condition(src => src.CorreoEmp != null))
             .ForMember(dest => dest.Curp, opt => opt.Condition(src => src.Curp != null))
             .ForMember(dest => dest.Rfc, opt => opt.Condition(src => src.Rfc != null))
             .ForMember(dest => dest.Nss, opt => opt.Condition(src => src.Nss != null))
             .ForMember(dest => dest.FechaAlta, opt => opt.Condition(src => src.FechaAlta != null))
             .ForMember(dest => dest.EmpStatus, opt => opt.Condition(src => src.EmpStatus != null))
             .ForMember(dest => dest.Puesto, opt => opt.Condition(src => src.Puesto != null))
             .ForMember(dest => dest.Sueldo, opt => opt.Condition(src => src.Sueldo != null));



            CreateMap<DTOEmpleado, Empleado>()
             .ForMember(dest => dest.IdEmpleado, opt => opt.Condition(src => src.IdEmpleado != null))
             .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null))
             .ForMember(dest => dest.NomP, opt => opt.Condition(src => src.NomP != null))
             .ForMember(dest => dest.ApP, opt => opt.Condition(src => src.ApP != null))
             .ForMember(dest => dest.ApM, opt => opt.Condition(src => src.ApM != null))
             .ForMember(dest => dest.Calle, opt => opt.Condition(src => src.Calle != null))
             .ForMember(dest => dest.Num, opt => opt.Condition(src => src.Num != null))
             .ForMember(dest => dest.Col, opt => opt.Condition(src => src.Col != null))
             .ForMember(dest => dest.Ciudad, opt => opt.Condition(src => src.Ciudad != null))
             .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != null))
             .ForMember(dest => dest.Pais, opt => opt.Condition(src => src.Pais != null))
             .ForMember(dest => dest.Cp, opt => opt.Condition(src => src.Cp != null))
             .ForMember(dest => dest.TelEmp, opt => opt.Condition(src => src.TelEmp != null))
             .ForMember(dest => dest.CorreoEmp, opt => opt.Condition(src => src.CorreoEmp != null))
             .ForMember(dest => dest.Curp, opt => opt.Condition(src => src.Curp != null))
             .ForMember(dest => dest.Rfc, opt => opt.Condition(src => src.Rfc != null))
             .ForMember(dest => dest.Nss, opt => opt.Condition(src => src.Nss != null))
             .ForMember(dest => dest.FechaAlta, opt => opt.Condition(src => src.FechaAlta != null))
             .ForMember(dest => dest.EmpStatus, opt => opt.Condition(src => src.EmpStatus != null))
             .ForMember(dest => dest.Puesto, opt => opt.Condition(src => src.Puesto != null))
             .ForMember(dest => dest.Sueldo, opt => opt.Condition(src => src.Sueldo != null));

            // Mapeo entre Producto y DTOProducto
            CreateMap <Producto, DTOProducto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap <DTOProducto, Producto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre Proveedores y DTOProveedores
            CreateMap<Proveedores, DTOProveedores>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOProveedores, Proveedores>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre SubCategoria y DTOSubCategoria
            CreateMap <SubCategoria, DTOSubCategoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap <DTOSubCategoria, SubCategoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
