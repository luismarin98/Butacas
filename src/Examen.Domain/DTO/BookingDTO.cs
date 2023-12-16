using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class BookingDTO
    {
        public int IdBookin { get; set; }

        public int IdCustomer { get; set; }

        public int IdBillboard { get; set; }

        public int IdSeat { get; set; }

        public DateTime Date { get; set; }
    }
}
