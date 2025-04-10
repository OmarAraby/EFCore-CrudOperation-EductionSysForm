

using EducationSysProject.Context;
using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationSysProject.Data.Repositories.StudentRepository
{
   public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationSysContext context) : base(context)
        {
        }

        public Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudentsWithCoursesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
