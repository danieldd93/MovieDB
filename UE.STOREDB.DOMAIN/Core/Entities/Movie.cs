using System;
using System.Collections.Generic;

namespace MovieDB.DOMAIN.Core.Entities;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Genre { get; set; }

    public int ReleaseYear { get; set; }

}
