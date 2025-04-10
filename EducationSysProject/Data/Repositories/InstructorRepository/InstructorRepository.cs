
using EducationSysProject.Context;
using EducationSysProject.Data.Models;

namespace EducationSysProject.Data.Repositories.InstructorRepository
{
   public class InstructorRepository : BaseRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(EducationSysContext context) : base(context)
        {
        }

        public Task<IEnumerable<Instructor>> GetInstructorsByDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> GetInstructorsWithCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Instructor?> GetInstructorWithCoursesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> SearchInstructorsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
    
}
