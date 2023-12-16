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
    public class BillboardRepository : IBillboard
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public BillboardRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<BillboardDTO>> GetBillboard()
        {
            try
            {
                ICollection<BillboardDTO> billboards = new List<BillboardDTO>();
                var response = await _context.BillboardEntities.ToListAsync();
                foreach (var entity in response)
                {
                    var mapper = _mapper.Map<BillboardDTO>(entity);
                    billboards.Add(mapper);
                }
                return billboards;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PutBillboard(int idBillboard, BillboardDTO billboard)
        {
            try
            {
                var response = await _context.BillboardEntities.FirstOrDefaultAsync(x => x.IdBillboard == idBillboard);
                if(response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<BillboardEntity>(billboard);

                    response.Date = mapper.Date;

                    _context.BillboardEntities.Update(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PostBillboard(BillboardDTO billboard)
        {
            try
            {
                var response = await _context.BillboardEntities.FirstOrDefaultAsync(x => x.IdBillboard == billboard.IdBillboard);
                if (response == null)
                {
                    var mapper = _mapper.Map<BillboardEntity>(billboard);
                    _context.BillboardEntities.Add(mapper);
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

        public async Task<bool> DeleteBillboard(int idBillboard)
        {
            try
            {
                var response = await _context.BillboardEntities.FirstOrDefaultAsync(x => x.IdBillboard == idBillboard);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    _context.BillboardEntities.Remove(response);
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
