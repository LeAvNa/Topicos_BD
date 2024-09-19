using AutoMapper;
using API_AntonioWalls.Models_Instancia2;
using API_AntonioWalls.DTOsucursal2;
namespace API_AntonioWalls.Mappings
{
    public class MappingProfile2 : Profile
    {
        public MappingProfile2()
        {
            // Mapeo entre Categoria y DTOCategoria
            CreateMap<Categoria, DTOCategoria2>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOCategoria2, Categoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre Cliente y DTOCliente
            CreateMap<Cliente, DTOCliente2>()
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

            CreateMap<DTOCliente2, Cliente>()
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
            CreateMap <Cocteleria,DTOCocteleria2>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOCocteleria2, Cocteleria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre Empleado y DTOEmpleado
            CreateMap <Empleado, DTOEmpleado2>()

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



            CreateMap<DTOEmpleado2, Empleado>()
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
            CreateMap<Producto, DTOProducto2>()
                .ForMember(dest => dest.IdProd, opt => opt.Condition(src => src.IdProd != null))
                .ForMember(dest => dest.CodBarra, opt => opt.Condition(src => src.CodBarra != null))
                .ForMember(dest => dest.PrecCom, opt => opt.Condition(src => src.PrecCom != null))
                .ForMember(dest => dest.PrecVen, opt => opt.Condition(src => src.PrecVen != null))
                .ForMember(dest => dest.CantV, opt => opt.Condition(src => src.CantV != null))
                .ForMember(dest => dest.Descr, opt => opt.Condition(src => src.Descr != null))
                .ForMember(dest => dest.CantMl, opt => opt.Condition(src => src.CantMl != null))
                .ForMember(dest => dest.StockMin, opt => opt.Condition(src => src.StockMin != null))
                .ForMember(dest => dest.StockMax, opt => opt.Condition(src => src.StockMax != null))
                .ForMember(dest => dest.IdCat, opt => opt.Condition(src => src.IdCat != null))
                .ForMember(dest => dest.IdSubcat, opt => opt.Condition(src => src.IdSubcat != null));
            
            CreateMap <DTOProducto2, Producto>()
                .ForMember(dest => dest.IdProd, opt => opt.Condition(src => src.IdProd != null))
                .ForMember(dest => dest.CodBarra, opt => opt.Condition(src => src.CodBarra != null))
                .ForMember(dest => dest.PrecCom, opt => opt.Condition(src => src.PrecCom != null))
                .ForMember(dest => dest.PrecVen, opt => opt.Condition(src => src.PrecVen != null))
                .ForMember(dest => dest.CantV, opt => opt.Condition(src => src.CantV != null))
                .ForMember(dest => dest.Descr, opt => opt.Condition(src => src.Descr != null))
                .ForMember(dest => dest.CantMl, opt => opt.Condition(src => src.CantMl != null))
                .ForMember(dest => dest.StockMin, opt => opt.Condition(src => src.StockMin != null))
                .ForMember(dest => dest.StockMax, opt => opt.Condition(src => src.StockMax != null))
                .ForMember(dest => dest.IdCat, opt => opt.Condition(src => src.IdCat != null))
                .ForMember(dest => dest.IdSubcat, opt => opt.Condition(src => src.IdSubcat != null));

            // Mapeo entre Proveedores y DTOProveedores
            CreateMap<Proveedores, DTOProveedores2>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<DTOProveedores2, Proveedores>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            // Mapeo entre SubCategoria y DTOSubCategoria
            CreateMap <SubCategoria, DTOSubCategoria2>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap <DTOSubCategoria2, SubCategoria>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;

            //Mapeo entre Venta y DTOVenta
            CreateMap<Venta, DTOVenta2>()
             .ForMember(dest => dest.IdVenta, opt => opt.Condition(src => src.IdVenta != null))
             .ForMember(dest => dest.FechaVenta, opt => opt.Condition(src => src.FechaVenta != null))
             .ForMember(dest => dest.Subtotal, opt => opt.Condition(src => src.Subtotal != null))
             .ForMember(dest => dest.Iva, opt => opt.Condition(src => src.Iva != null))
             .ForMember(dest => dest.Total, opt => opt.Condition(src => src.Total != null))
             .ForMember(dest => dest.MetPago, opt => opt.Condition(src => src.MetPago != null))
             .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null));

            CreateMap<DTOVenta2, Venta>()
             .ForMember(dest => dest.IdVenta, opt => opt.Condition(src => src.IdVenta != null))
             .ForMember(dest => dest.FechaVenta, opt => opt.Condition(src => src.FechaVenta != null))
             .ForMember(dest => dest.Subtotal, opt => opt.Condition(src => src.Subtotal != null))
             .ForMember(dest => dest.Iva, opt => opt.Condition(src => src.Iva != null))
             .ForMember(dest => dest.Total, opt => opt.Condition(src => src.Total != null))
             .ForMember(dest => dest.MetPago, opt => opt.Condition(src => src.MetPago != null))
             .ForMember(dest => dest.IdSucursal, opt => opt.Condition(src => src.IdSucursal != null));

        }
    }
}
