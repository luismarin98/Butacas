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
    public class RoomRepository : IRoom
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<RoomDTO>> GetRooms()
        {
            try
            {
                ICollection<RoomDTO> rooms = new List<RoomDTO>();
                var response = await _context.RoomEntities.Include(x => x.BillboardEntities).ToListAsync();
                foreach (var entity in response)
                {
                    var mapper = _mapper.Map<RoomDTO>(entity);
                    rooms.Add(mapper);
                }
                return rooms;
            }
            catch(Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PostRoom(RoomDTO room)
        {
            try
            {
                var response = await _context.RoomEntities.FirstOrDefaultAsync(x => x.IdRoom == room.IdRoom);
                if (response == null)
                {
                    var mapper = _mapper.Map<RoomEntity>(room);
                    _context.RoomEntities.Add(mapper);
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
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PutRoom(int idRoom, RoomDTO room)
        {
            try
            {
                var response = await _context.RoomEntities.FirstOrDefaultAsync(x => x.IdRoom == idRoom);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<RoomEntity>(room);

                    response.Number = mapper.Number;
                    response.Name = mapper.Name;

                    _context.RoomEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> DeleteRoom(int idRoom)
        {
            try
            {
                var response = await _context.RoomEntities.FirstOrDefaultAsync(x => x.IdRoom == idRoom);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var relatedSeats = await _context.SeatEntities.Where(s => s.IdRoom == idRoom).ToListAsync();
                    _context.SeatEntities.RemoveRange(relatedSeats);

                    _context.RoomEntities.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                return false;
            }
        }
    }
}
