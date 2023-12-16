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
    public class BookingRepository : IBooking
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> PostBooking(BookingDTO book)
        {
            try
            {
                var resCustomer = await _context.CustomerEntities.FirstOrDefaultAsync(x => x.IdCustomer == book.IdCustomer);
                var resBill = await _context.BillboardEntities.FirstOrDefaultAsync(x => x.IdBillboard == book.IdBillboard);
                var resSeat = await _context.SeatEntities.FirstOrDefaultAsync(x => x.IdSeat ==  book.IdSeat);

                if(resCustomer != null && resBill != null && resSeat != null)
                {
                    var response = await _context.BookingEntities.FirstOrDefaultAsync(x => x.IdBookin == book.IdBookin);
                    if (response == null)
                    {
                        var mapper = _mapper.Map<BookingEntity>(book);
                        _context.BookingEntities.Add(mapper);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PutBooking(int idBooking, BookingDTO book)
        {
            try
            {
                var response = await _context.BookingEntities.FirstOrDefaultAsync(x => x.IdBookin == idBooking);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<BookingEntity>(book);

                    response.Date = mapper.Date;

                    _context.BookingEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> DeleteBooking(int idBook)
        {
            try
            {
                var response = await _context.BookingEntities.FirstOrDefaultAsync(x => x.IdBookin == idBook);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    _context.BookingEntities.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<ICollection<BookingDTO>> GetBookings()
        {
            try
            {
                ICollection<BookingDTO> bookings = new List<BookingDTO>();
                var response = await _context.BookingEntities.ToListAsync();
                foreach (var item in response)
                {
                    var mapper = _mapper.Map<BookingDTO>(item);
                    bookings.Add(mapper);
                }
                return bookings;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
