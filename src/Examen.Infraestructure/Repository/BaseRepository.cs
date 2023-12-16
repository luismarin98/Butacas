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
    public class BaseRepository : IBase
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<BaseDTO>> GetBases()
        {
            try
            {
                ICollection<BaseDTO> baseList = new List<BaseDTO>();
                var response = await _context.BaseEntities.ToListAsync();
                foreach (var dto in response) 
                {
                    var mapper = _mapper.Map<BaseDTO>(dto);
                    baseList.Add(mapper);
                }
                return baseList;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PostBase(BaseDTO baseDTO)
        {
            try
            {
                var response = await _context.BaseEntities.FirstOrDefaultAsync(x => x.IdBase == baseDTO.IdBase);
                if(response == null)
                {
                    var mapper = _mapper.Map<BaseEntity>(baseDTO);
                    _context.BaseEntities.Add(mapper);
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

        public async Task<bool> PutCBase(int idBase, BaseDTO baseDTO)
        {
            try
            {
                var response = await _context.BaseEntities.FirstOrDefaultAsync(x => x.IdBase == idBase);
                if(response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<BaseEntity>(baseDTO);

                    response.Status = mapper.Status;

                    _context.BaseEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> DeleteBase(int idBase)
        {
            try
            {
                var response = await _context.BaseEntities.FirstOrDefaultAsync(x => x.IdBase == idBase);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    _context.BaseEntities.Remove(response);
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
