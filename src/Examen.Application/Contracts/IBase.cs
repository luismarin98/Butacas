using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface IBase
    {
        Task<ICollection<BaseDTO>> GetBases();

        Task<bool> PostBase(BaseDTO baseDTO);

        Task<bool> PutCBase(int idBase, BaseDTO baseDTO);

        Task<bool> DeleteBase(int idBase);
    }
}
