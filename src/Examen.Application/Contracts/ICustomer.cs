using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface ICustomer
    {
        Task<ICollection<CustomerEntity>> GetCustomers();

        Task<bool> PostCustomer(CustomerDTO customer);

        Task<bool> PutCustomer(int idCustomer, CustomerDTO customer);

        Task<bool> DeleteCustomer(int idCustomer);
    }
}
