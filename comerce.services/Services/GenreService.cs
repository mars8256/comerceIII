using comerce.Core.Entities;
using comerce.Core.Interfaces;
using comerce.Core.Interfaces.Services;
using comerce.Services.Validators;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {
            GenreValidator validator = new();

            var validatorResult = await validator.ValidateAsync(genre);

            if (!validatorResult.IsValid) 
                throw new ArgumentException(validatorResult.Errors.ToString());

            await _unitOfWork.GenreRepository.AddAsync(genre);

            await _unitOfWork.CommitAsync();

            return genre;
        }

        public async Task DeleteGenre(int id)
        {
            var current = await _unitOfWork.GenreRepository.GetByIdAsync(id);

            if (current == null)
                throw new ArgumentException("Not found");

            _unitOfWork.GenreRepository.Remove(current);

            await _unitOfWork.CommitAsync();
           
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _unitOfWork.GenreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _unitOfWork.GenreRepository.GetByIdAsync(id);
        }

        public async Task<Genre> UpdateGenre(int id, Genre genre)
        {
            
            GenreValidator validator = new();

            var validatorResult = await validator.ValidateAsync(genre);

            if (!validatorResult.IsValid)
                throw new ArgumentException(validatorResult.Errors.ToString());

            var current = await _unitOfWork.GenreRepository.GetByIdAsync(id);

            if (current == null)
                throw new ArgumentException("Not found");

            current.Name = genre.Name;

            await _unitOfWork.GenreRepository.Update(current);

            await _unitOfWork.CommitAsync();
            
            return current;
        }
    }
}
