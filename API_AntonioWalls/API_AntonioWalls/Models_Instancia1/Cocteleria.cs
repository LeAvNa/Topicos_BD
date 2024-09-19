using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class Cocteleria
{
    public int IdCoct { get; set; }

    public string? Nombre { get; set; }

    public string? Mezcla { get; set; }

    public string? Descr { get; set; }

    public decimal? PrecVent { get; set; }
}
