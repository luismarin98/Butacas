using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface IBooking
    {
        Task<ICollection<BookingDTO>> GetBookings();

        Task<bool> PostBooking(BookingDTO book);

        Task<bool> PutBooking(int idBook, BookingDTO book);

        Task<bool> DeleteBooking(int idBook);
    }
}
