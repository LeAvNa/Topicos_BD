using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class Genera
{
    public int IdVenta { get; set; }

    public int IdEmpleado { get; set; }

    public int IdCliente { get; set; }

    public decimal? Propina { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
