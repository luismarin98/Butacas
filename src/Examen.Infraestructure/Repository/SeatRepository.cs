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
    public class SeatRepository : ISeat
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public SeatRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<SeatDTO>> GetSeat()
        {
            try
            {
                ICollection<SeatDTO> seats = new List<SeatDTO>();
                var response = await _context.SeatEntities.Include(x => x.BookingEntities).ToListAsync();
                foreach (var item in response)
                {
                    var mapper = _mapper.Map<SeatDTO>(response);
                    seats.Add(mapper);
                }
                return seats;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PostSeat(SeatDTO seat)
        {
            var roomExists = await _context.RoomEntities.AnyAsync(r => r.IdRoom == seat.IdRoom);

            if (!roomExists)
            {
                // La habitación asociada no existe, maneja este escenario según sea necesario
                return false;
            }

            var existingSeat = await _context.SeatEntities.FirstOrDefaultAsync(x => x.IdSeat == seat.IdSeat);

            if (existingSeat == null)
            {
                var newSeat = new SeatEntity
                {
                    // Asigna otras propiedades de Seat a la nueva SeatEntity
                    IdRoom = seat.IdRoom, // Asegúrate de que este valor exista en RoomEntity
                                          // Otras asignaciones de propiedades aquí
                };

                _context.SeatEntities.Add(newSeat);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> PutSeat(SeatDTO seat, int idSeat)
        {
            try
            {
                var response = await _context.SeatEntities.FirstOrDefaultAsync(x => x.IdSeat == idSeat);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<SeatEntity>(seat);

                    response.Number = mapper.Number;
                    response.RowNumber = mapper.RowNumber;

                    _context.SeatEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> DeleteSeat(int idSeat)
        {
            try
            {
                var response = await _context.SeatEntities.FirstOrDefaultAsync(x => x.IdSeat == idSeat);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    _context.SeatEntities.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
