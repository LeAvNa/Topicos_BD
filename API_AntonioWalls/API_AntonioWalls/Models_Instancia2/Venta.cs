using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia2;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Total { get; set; }

    public string? MetPago { get; set; }

    public int IdSucursal { get; set; }

    public virtual Sucursales IdSucursalNavigation { get; set; } = null!;
}
