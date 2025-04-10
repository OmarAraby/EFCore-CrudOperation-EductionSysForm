using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.StudentRepository
{
     public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseID);
        Task<IEnumerable<Student>> GetStudentsWithCoursesAsync();
        Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(Guid departmentId);


    }
}
