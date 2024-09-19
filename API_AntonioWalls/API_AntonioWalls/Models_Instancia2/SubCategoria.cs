using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia2;

public partial class SubCategoria
{
    public int IdSubcat { get; set; }

    public string? NomSubcat { get; set; }

    public int IdCat { get; set; }

    public virtual Categoria IdCatNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
