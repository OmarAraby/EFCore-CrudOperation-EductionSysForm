using EducationSysProject.Data.Repositories;
using EducationSysProject.Data.UintOfWork;
using System;
using System.Threading.Tasks;

namespace EducationSysProject.Services
{
    public class GenericCrudService : IGenericCrudService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericCrudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<T?> GetByIdAsync<T>(Guid id) where T : class
        {
            var repository = GetRepositoryForType<T>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var repository = GetRepositoryForType<T>();
            return await repository.GetAllAsync();
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            var repository = GetRepositoryForType<T>();
            await repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var repository = GetRepositoryForType<T>();
            await repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            var repository = GetRepositoryForType<T>();
            await repository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        private IRepository<T> GetRepositoryForType<T>() where T : class
        {
            var repositoryProperty = _unitOfWork.GetType().GetProperty($"{typeof(T).Name}s");
            if (repositoryProperty == null)
                throw new InvalidOperationException($"No repository found for type {typeof(T).Name}");

            return (IRepository<T>)repositoryProperty.GetValue(_unitOfWork);
        }
    }
}