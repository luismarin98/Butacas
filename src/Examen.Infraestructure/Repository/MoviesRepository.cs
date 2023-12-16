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
    public class MoviesRepository : IMovie
    {
        private readonly ButacasContext _context;
        private readonly IMapper _mapper;

        public MoviesRepository(ButacasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> PutMovie(int idMovie, MovieDTO movieDTO)
        {
            try
            {
                var response = await _context.MovieEntities.FirstOrDefaultAsync(x => x.IdMovie == idMovie);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    var mapper = _mapper.Map<MovieEntity>(movieDTO);

                    response.AllowedAge = mapper.AllowedAge;
                    response.MovieGenreEnum = mapper.MovieGenreEnum;
                    response.Name = mapper.Name;
                    response.LengthMinutes = mapper.LengthMinutes;

                    _context.MovieEntities.Remove(mapper);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> DeleteMovie(int idMovie)
        {
            try
            {
                var response = await _context.MovieEntities.FirstOrDefaultAsync(x => x.IdMovie == idMovie);
                if (response == null)
                {
                    return false;
                }
                else
                {
                    _context.MovieEntities.Remove(response);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }

        public async Task<bool> PostMovie(MovieDTO movieDTO)
        {
            try
            {
                var response = await _context.MovieEntities.FirstOrDefaultAsync(x => x.Name == movieDTO.Name);
                if (response == null)
                {
                    var mapper = _mapper.Map<MovieEntity>(movieDTO);
                    _context.MovieEntities.Add(mapper);
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

        public async Task<ICollection<MovieDTO>> GetMovies()
        {
            try
            {
                ICollection<MovieDTO> movies = new List<MovieDTO>();
                var response = await _context.MovieEntities.ToListAsync();
                foreach (var movie in response)
                {
                    var mapper = _mapper.Map<MovieDTO>(movie);
                    movies.Add(mapper);
                }
                return movies;
            }
            catch (Exception ex)
            {
                throw new NotFiniteNumberException(ex.Message);
            }
        }
    }
}
