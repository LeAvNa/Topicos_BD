using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia2;

public partial class Provee
{
    public int IdProv { get; set; }

    public int IdProd { get; set; }

    public virtual Producto IdProdNavigation { get; set; } = null!;

    public virtual Proveedores IdProvNavigation { get; set; } = null!;
}
