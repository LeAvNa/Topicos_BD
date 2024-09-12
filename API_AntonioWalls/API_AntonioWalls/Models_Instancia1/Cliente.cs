using System;
using System.Collections.Generic;

namespace API_AntonioWalls.Models_Instancia1;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NomP { get; set; }

    public string? ApP { get; set; }

    public string? ApM { get; set; }

    public string? Calle { get; set; }

    public int? Num { get; set; }

    public string? Col { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public int? Cp { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Rfc { get; set; }

    public DateTime? FechaReg { get; set; }

    public int IdSucursal { get; set; }

    public virtual Sucursales IdSucursalNavigation { get; set; } = null!;
}
