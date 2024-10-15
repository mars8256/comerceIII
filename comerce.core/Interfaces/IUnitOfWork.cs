using comerce.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenreRepository GenreRepository { get; }
        IConcertRepository ConcertRepository { get; }
        Task<int> CommitAsync();
    }
}
