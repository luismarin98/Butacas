using System;
using System.Collections.Generic;

public partial class MovieEntity
{
    public int IdMovie { get; set; }

    public string Name { get; set; } = null!;

    public string MovieGenreEnum { get; set; } = null!;

    public int AllowedAge { get; set; }

    public int LengthMinutes { get; set; }

    public virtual ICollection<BillboardEntity> BillboardEntities { get; set; } = new List<BillboardEntity>();
}
