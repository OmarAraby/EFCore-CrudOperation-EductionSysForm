using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.DepartmentRepository
{
     public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetDepartmentsWithCoursesAsync();
        Task<IEnumerable<Department>> GetDepartmentsWithInstructorsAsync();
        Task<Department?> GetDepartmentWithCoursesAndInstructorsAsync(Guid id);
        Task<IEnumerable<Department>> SearchDepartmentsByNameAsync(string name);
    }
}
