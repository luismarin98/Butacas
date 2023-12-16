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

    }
}
