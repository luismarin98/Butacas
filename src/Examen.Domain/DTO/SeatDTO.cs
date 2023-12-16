using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class SeatDTO
    {
        public int IdSeat { get; set; }

        public int IdRoom { get; set; }

        public string Number { get; set; } = null!;

        public int RowNumber { get; set; }
    }
}
