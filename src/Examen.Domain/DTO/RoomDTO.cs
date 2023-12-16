using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class RoomDTO
    {
        public int IdRoom { get; set; }

        public string Name { get; set; } = null!;

        public int Number { get; set; }

        public virtual ICollection<BillboardEntity> BillboardEntities { get; set; } = new List<BillboardEntity>();

        public virtual ICollection<SeatEntity> SeatEntities { get; set; } = new List<SeatEntity>();
    }
}
