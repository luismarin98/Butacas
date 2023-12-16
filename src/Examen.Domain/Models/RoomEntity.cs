using System;
using System.Collections.Generic;
public partial class RoomEntity
{
    public int IdRoom { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<BillboardEntity> BillboardEntities { get; set; } = new List<BillboardEntity>();

    public virtual ICollection<SeatEntity> SeatEntities { get; set; } = new List<SeatEntity>();
}
