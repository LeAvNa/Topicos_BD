using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class Categoria
{
    public int IdCat { get; set; }

    public string? NomCat { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();
}
