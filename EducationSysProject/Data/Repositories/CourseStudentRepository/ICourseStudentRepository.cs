using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.CourseStudentRepository
{
    public interface ICourseStudentRepository : IRepository<CourseStudent>
    {
        Task<IEnumerable<CourseStudent>> GetEnrollmentsByStudentAsync(Guid studentId);
        Task<IEnumerable<CourseStudent>> GetEnrollmentsByCourseAsync(Guid courseId);
        Task<bool> IsStudentEnrolledAsync(Guid studentId, Guid courseId);
        Task<int> GetEnrollmentCountForCourseAsync(Guid courseId);
    }
}
