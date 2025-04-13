using EducationSysProject.Data.Models;
using EducationSysProject.Data.Repositories;
using EducationSysProject.Data.UintOfWork;
using System;
using System.Threading.Tasks;

namespace EducationSysProject.Services
{
    public class GenericCrudService : IGenericCrudService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dictionary<Type, object> _repositories;

        public GenericCrudService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositories = new Dictionary<Type, object>
        {
            { typeof(Student), _unitOfWork.Students },
            { typeof(Department), _unitOfWork.Departments },
            { typeof(Instructor), _unitOfWork.Instructors },
            { typeof(Course), _unitOfWork.Courses },
            { typeof(CourseSession), _unitOfWork.CourseSessions },
            { typeof(CourseStudent), _unitOfWork.CourseStudents },
            { typeof(CourseSessionAttendance), _unitOfWork.CourseSessionAttendances }
        };
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
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }
            throw new InvalidOperationException($"No repository found for type {typeof(T).Name}");
        }
    }
}