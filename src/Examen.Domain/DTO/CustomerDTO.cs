using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.DTO
{
    public partial class CustomerDTO
    {
        public int IdCustomer { get; set; }

        public int DocumentNumber { get; set; }

        public string Name { get; set; } = null!;

        public string Latname { get; set; } = null!;

        public int Age { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; } = null!;
    }
}
