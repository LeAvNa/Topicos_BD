using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia2;

public partial class Producto
{
    public int IdProd { get; set; }

    public long? CodBarra { get; set; }

    public decimal? PrecCom { get; set; }

    public decimal? PrecVen { get; set; }

    public int? CantV { get; set; }

    public string? Descr { get; set; }

    public int? CantMl { get; set; }

    public int? StockMin { get; set; }

    public int? StockMax { get; set; }

    public int IdCat { get; set; }

    public int IdSubcat { get; set; }

    public virtual Categoria IdCatNavigation { get; set; } = null!;

    public virtual SubCategoria IdSubcatNavigation { get; set; } = null!;
}
