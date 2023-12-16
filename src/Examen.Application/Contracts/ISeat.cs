using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface ISeat
    {
        Task<ICollection<SeatDTO>> GetSeat();

        Task<bool> PostSeat(SeatDTO seat);

        Task<bool> PutSeat(SeatDTO seat, int idSeat);

        Task<bool> DeleteSeat(int idSeat);
    }
}
