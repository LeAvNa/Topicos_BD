using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_AntonioWalls.Models_Instancia2;

public partial class Sucursal2Context : DbContext
{
    public Sucursal2Context()
    {
    }

    public Sucursal2Context(DbContextOptions<Sucursal2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cocteleria> Cocteleria { get; set; }

    public virtual DbSet<DetVenta> DetVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadosStat> EmpleadosStats { get; set; }

    public virtual DbSet<Genera> Generas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Provee> Provees { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<SubCategoria> SubCategorias { get; set; }

    public virtual DbSet<Sucursales> Sucursales { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__Categori__D54686DE3FC98B75");

            entity.Property(e => e.IdCat)
                .ValueGeneratedNever()
                .HasColumnName("id_cat");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NomCat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_cat");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F5AF7459C4");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.ApM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ap_m");
            entity.Property(e => e.ApP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ap_p");
            entity.Property(e => e.Calle)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Col)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("col");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaReg).HasColumnName("fecha_reg");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.NomP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_p");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__id_suc__398D8EEE");
        });

        modelBuilder.Entity<Cocteleria>(entity =>
        {
            entity.HasKey(e => e.IdCoct).HasName("PK__Cocteler__6D69ED6931003899");

            entity.Property(e => e.IdCoct)
                .ValueGeneratedNever()
                .HasColumnName("id_coct");
            entity.Property(e => e.Descr)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.Mezcla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mezcla");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecVent)
                .HasColumnType("money")
                .HasColumnName("prec_vent");
        });

        modelBuilder.Entity<DetVenta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("det_venta");

            entity.Property(e => e.CantE).HasColumnName("cant_e");
            entity.Property(e => e.IdCoct).HasColumnName("id_coct");
            entity.Property(e => e.IdProd).HasColumnName("id_prod");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Importe)
                .HasColumnType("money")
                .HasColumnName("importe");
            entity.Property(e => e.Pmv)
                .HasColumnType("money")
                .HasColumnName("pmv");

            entity.HasOne(d => d.IdCoctNavigation).WithMany()
                .HasForeignKey(d => d.IdCoct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__det_venta__id_co__5535A963");

            entity.HasOne(d => d.IdProdNavigation).WithMany()
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__det_venta__id_pr__5629CD9C");

            entity.HasOne(d => d.IdVentaNavigation).WithMany()
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__det_venta__id_ve__571DF1D5");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__88B51394FCDC23BE");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("id_empleado");
            entity.Property(e => e.ApM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ap_m");
            entity.Property(e => e.ApP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ap_p");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Col)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("col");
            entity.Property(e => e.CorreoEmp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_emp");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Curp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("curp");
            entity.Property(e => e.EmpStatus)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("emp_status");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAlta).HasColumnName("fecha_alta");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.NomP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_p");
            entity.Property(e => e.Nss)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nss");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("puesto");
            entity.Property(e => e.Rfc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.Sueldo)
                .HasColumnType("money")
                .HasColumnName("sueldo");
            entity.Property(e => e.TelEmp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel_emp");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__id_su__3C69FB99");
        });

        modelBuilder.Entity<EmpleadosStat>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__88B51394DDAD63EB");

            entity.ToTable("EmpleadosStat");

            entity.Property(e => e.IdEmpleado)
                .ValueGeneratedNever()
                .HasColumnName("id_empleado");
            entity.Property(e => e.ApP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ap_p");
            entity.Property(e => e.EmpStatus)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("emp_status");
            entity.Property(e => e.NomP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_p");
            entity.Property(e => e.Sueldo)
                .HasColumnType("money")
                .HasColumnName("sueldo");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithOne(p => p.EmpleadosStat)
                .HasForeignKey<EmpleadosStat>(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__id_em__5CD6CB2B");
        });

        modelBuilder.Entity<Genera>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("genera");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Propina)
                .HasColumnType("money")
                .HasColumnName("propina");

            entity.HasOne(d => d.IdClienteNavigation).WithMany()
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__genera__id_clien__4316F928");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany()
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__genera__id_emple__440B1D61");

            entity.HasOne(d => d.IdVentaNavigation).WithMany()
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__genera__id_venta__4222D4EF");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PK__Producto__0DA3487339283B8E");

            entity.Property(e => e.IdProd)
                .ValueGeneratedNever()
                .HasColumnName("id_prod");
            entity.Property(e => e.CantMl).HasColumnName("cant_ml");
            entity.Property(e => e.CantV).HasColumnName("cant_v");
            entity.Property(e => e.CodBarra).HasColumnName("cod_barra");
            entity.Property(e => e.Descr)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descr");
            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.IdSubcat).HasColumnName("id_subcat");
            entity.Property(e => e.PrecCom)
                .HasColumnType("money")
                .HasColumnName("prec_com");
            entity.Property(e => e.PrecVen)
                .HasColumnType("money")
                .HasColumnName("prec_ven");
            entity.Property(e => e.StockMax).HasColumnName("stock_max");
            entity.Property(e => e.StockMin).HasColumnName("stock_min");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__id_ca__4D94879B");

            entity.HasOne(d => d.IdSubcatNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSubcat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__id_su__4E88ABD4");
        });

        modelBuilder.Entity<Provee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("provee");

            entity.Property(e => e.IdProd).HasColumnName("id_prod");
            entity.Property(e => e.IdProv).HasColumnName("id_prov");

            entity.HasOne(d => d.IdProdNavigation).WithMany()
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__provee__id_prod__5165187F");

            entity.HasOne(d => d.IdProvNavigation).WithMany()
                .HasForeignKey(d => d.IdProv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__provee__id_prov__5070F446");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProv).HasName("PK__Proveedo__0DA3485DED5FB6A2");

            entity.Property(e => e.IdProv)
                .ValueGeneratedNever()
                .HasColumnName("id_prov");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Col)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("col");
            entity.Property(e => e.CorreoProv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_prov");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.RazSoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("raz_soc");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.TelProv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel_prov");
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.IdSubcat).HasName("PK__Sub_Cate__739219165EED173C");

            entity.ToTable("Sub_Categorias");

            entity.Property(e => e.IdSubcat)
                .ValueGeneratedNever()
                .HasColumnName("id_subcat");
            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.NomSubcat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_subcat");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.IdCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sub_Categ__id_ca__4AB81AF0");
        });

        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__4C7580131C3CFFDF");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("id_sucursal");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Col)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("col");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAp).HasColumnName("fecha_ap");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Presup)
                .HasColumnType("money")
                .HasColumnName("presup");
            entity.Property(e => e.RazSoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("raz_soc");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.TelefonoSuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_suc");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__459533BF49B2C18A");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedNever()
                .HasColumnName("id_venta");
            entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta");
            entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");
            entity.Property(e => e.Iva)
                .HasColumnType("money")
                .HasColumnName("iva");
            entity.Property(e => e.MetPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("met_pago");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__id_sucur__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
