using EducationSysProject.Data.Models;
using EducationSysProject.Data.UintOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EducationSysProject.Services
{
    public interface IGenericCrudService
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}

