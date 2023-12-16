using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface IBillboard
    {
        Task<ICollection<BillboardDTO>> GetBillboard();

        Task<bool> PostBillboard(BillboardDTO customer);

        Task<bool> PutBillboard(int idBillboard, BillboardDTO billboard);

        Task<bool> DeleteBillboard(int idBillboard);
    }
}
