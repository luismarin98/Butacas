using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class BookingEntity
{
    public int IdBookin { get; set; }

    public int IdCustomer { get; set; }

    public int IdBillboard { get; set; }

    public int IdSeat { get; set; }

    public DateTime Date { get; set; }

    [JsonIgnore]
    public virtual BillboardEntity IdBillboardNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual CustomerEntity IdCustomerNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual SeatEntity IdSeatNavigation { get; set; } = null!;
}
