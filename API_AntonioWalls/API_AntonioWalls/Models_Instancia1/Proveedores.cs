﻿using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class Proveedores
{
    public int IdProv { get; set; }

    public string? RazSoc { get; set; }

    public string? Rfc { get; set; }

    public string? Calle { get; set; }

    public int? Num { get; set; }

    public string? Col { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public int? Cp { get; set; }

    public string? TelProv { get; set; }

    public string? CorreoProv { get; set; }
}
