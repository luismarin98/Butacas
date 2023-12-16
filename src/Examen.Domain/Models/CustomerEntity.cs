using System;
using System.Collections.Generic;
public partial class CustomerEntity
{
    public int IdCustomer { get; set; }

    public int DocumentNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Latname { get; set; } = null!;

    public int Age { get; set; }

    public int PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<BookingEntity> BookingEntities { get; set; } = new List<BookingEntity>();
}
