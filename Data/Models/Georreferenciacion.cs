using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Georreferenciacion
{
    public int Id { get; set; }

    public string? NombreCiudad { get; set; }

    public string? GeorreferenciaJson { get; set; }
}
