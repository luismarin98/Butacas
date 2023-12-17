using AutoMapper;
using Examen.Application.Contracts;
using Examen.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infraestructure.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCustomer(int idCustomer)
        {
            try
            {
                var response = await _context.CustomerEntities.FirstOrDefaultAsync(x => x.IdCustomer == idCustomer);

                if (response == null)
                {
                    return false; // El cliente no existe
                }
                else
                {
                    var hasBookings = _context.BookingEntities.Any(b => b.IdCustomer == idCustomer);

                    if (hasBookings)
                    {
                        // Eliminar al cliente y todas las reservas asociadas
                        var bookingsToDelete = _context.BookingEntities.Where(b => b.IdCustomer == idCustomer);
                        _context.BookingEntities.RemoveRange(bookingsToDelete);
                    }

                    // Siempre se elimina al cliente, ya sea que tenga reservas o no
                    _context.CustomerEntities.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> PutCustomer(int idCustomer, CustomerDTO customer)
        {
            try
            {
                var response = await _context.CustomerEntities.FirstOrDefaultAsync(x => x.IdCustomer == idCustomer);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<CustomerEntity>(customer);

                    response.DocumentNumber = mapper.DocumentNumber;
                    response.Name = mapper.Name;
                    response.Latname = mapper.Latname;
                    response.PhoneNumber = mapper.PhoneNumber;
                    response.Email = mapper.Email;

                    _context.CustomerEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> PostCustomer(CustomerDTO customer)
        {
            try
            {
                var response = await _context.CustomerEntities.FirstOrDefaultAsync(x => x.IdCustomer == customer.IdCustomer);
                if(response == null)
                {
                    var mapper = _mapper.Map<CustomerEntity>(customer);
                    _context.CustomerEntities.Add(mapper);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<ICollection<CustomerDTO>> GetCustomers()
        {
            try
            {
                ICollection<CustomerDTO> customers = new List<CustomerDTO>();
                var response = await _context.CustomerEntities.Include(x => x.BookingEntities).ToListAsync();

                foreach (var customer in response)
                {
                    var mapper = _mapper.Map<CustomerDTO>(customer);
                    customers.Add(mapper);
                }

                return customers;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
