using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia2;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NomP { get; set; }

    public string? ApP { get; set; }

    public string? ApM { get; set; }

    public string? Calle { get; set; }

    public int? Num { get; set; }

    public string? Col { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public int? Cp { get; set; }

    public string? TelEmp { get; set; }

    public string? CorreoEmp { get; set; }

    public string? Curp { get; set; }

    public string? Rfc { get; set; }

    public string? Nss { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public string? EmpStatus { get; set; }

    public string? Puesto { get; set; }

    public decimal? Sueldo { get; set; }

    public int IdSucursal { get; set; }

    public virtual EmpleadosStat? EmpleadosStat { get; set; }

    public virtual Sucursales IdSucursalNavigation { get; set; } = null!;
}
