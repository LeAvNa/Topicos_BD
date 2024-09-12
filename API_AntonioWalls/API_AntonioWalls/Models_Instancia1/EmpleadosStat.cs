using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class EmpleadosStat
{
    public int IdEmpleado { get; set; }

    public string? NomP { get; set; }

    public string? ApP { get; set; }

    public decimal? Sueldo { get; set; }

    public string? EmpStatus { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
