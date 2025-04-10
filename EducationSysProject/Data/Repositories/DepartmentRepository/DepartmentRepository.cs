

using EducationSysProject.Context;
using EducationSysProject.Data.Models;

namespace EducationSysProject.Data.Repositories.DepartmentRepository
{
   public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EducationSysContext context) : base(context)
        {
        }
        public Task<IEnumerable<Department>> GetDepartmentsWithCoursesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Department>> GetDepartmentsWithInstructorsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Department?> GetDepartmentWithCoursesAndInstructorsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Department>> SearchDepartmentsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }   
    
}
