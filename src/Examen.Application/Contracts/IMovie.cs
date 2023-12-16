using Examen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Contracts
{
    public interface IMovie
    {
        Task<bool> PostMovie(MovieDTO movie);

        Task<bool> PutMovie(int idMovie, MovieDTO movie);

        Task<bool> DeleteMovie(int idMovie);

        Task<ICollection<MovieDTO>> GetMovies();
    }
}
