using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Ciudad { get; set; } = null!;
}
