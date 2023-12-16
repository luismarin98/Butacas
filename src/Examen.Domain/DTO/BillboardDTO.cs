using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class BillboardDTO
    {
        public int IdBillboard { get; set; }

        public int IdMovie { get; set; }

        public int IdRoom { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
