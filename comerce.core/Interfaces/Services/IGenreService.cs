using comerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<Genre> GetGenreById(int id);
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> CreateGenre(Genre genre);
        Task<Genre> UpdateGenre(int id, Genre genre);
        Task DeleteGenre(int id);
    }
}
