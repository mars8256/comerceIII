using comerce.Core.Entities;
using comerce.Core.Interfaces.Repositories;
using comerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicStoreDbContext context) : base(context)
        {
        }
    }
}
