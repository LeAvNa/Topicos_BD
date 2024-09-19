using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class DetVenta
{
    public decimal? Pmv { get; set; }

    public int? CantE { get; set; }

    public decimal? Importe { get; set; }

    public int IdCoct { get; set; }

    public int IdProd { get; set; }

    public int IdVenta { get; set; }

    public virtual Cocteleria IdCoctNavigation { get; set; } = null!;

    public virtual Producto IdProdNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
