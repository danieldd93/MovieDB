using System;
using System.Collections.Generic;

namespace MovieDB.DOMAIN.Core.Entities;

public partial class Director
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Country { get; set; }

    public string? Biography { get; set; }
}
