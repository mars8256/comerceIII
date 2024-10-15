using comerce.Core.Interfaces;
using comerce.Core.Interfaces.Repositories;
using comerce.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicStoreDbContext _context;
        private GenreRepository _GenreRepository;
        //private ConcertRepository _concertRepository;
        //private ClassroomRepository _classroomRepository;

        public UnitOfWork(MusicStoreDbContext context)
        {
            _context = context;
        }
        public IGenreRepository GenreRepository => _GenreRepository ?? new GenreRepository(_context);

        public IConcertRepository ConcertRepository => throw new NotImplementedException();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
