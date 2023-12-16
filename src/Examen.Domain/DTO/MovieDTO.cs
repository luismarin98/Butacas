using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class MovieDTO
    {
        public int IdMovie { get; set; }

        public string Name { get; set; } = null!;

        public string MovieGenreEnum { get; set; } = null!;

        public int AllowedAge { get; set; }

        public int LengthMinutes { get; set; }

    }
}
