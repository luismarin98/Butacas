using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface IRoom
    {
        Task<ICollection<RoomDTO>> GetRooms();

        Task<bool> PostRoom(RoomDTO room);

        Task<bool> PutRoom(int idRoom, RoomDTO room);

        Task<bool> DeleteRoom(int idRoom);
    }
}
