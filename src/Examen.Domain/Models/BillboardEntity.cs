using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class BillboardEntity 
{
    public int IdBillboard { get; set; }

    public int IdMovie { get; set; }

    public int IdRoom { get; set; }

    public DateTime Date { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<BookingEntity> BookingEntities { get; set; } = new List<BookingEntity>();

    [JsonIgnore]
    public virtual MovieEntity IdMovieNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual RoomEntity IdRoomNavigation { get; set; } = null!;
}
