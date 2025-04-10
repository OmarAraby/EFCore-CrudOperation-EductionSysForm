using EducationSysProject.Context;
using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.CourseStudentRepository
{
   public class CourseStudentRepository : BaseRepository<CourseStudent>, ICourseStudentRepository
    {
        public CourseStudentRepository(EducationSysContext context) : base(context)
        {
        }
        public Task<IEnumerable<CourseStudent>> GetEnrollmentsByStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<CourseStudent>> GetEnrollmentsByCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsStudentEnrolledAsync(Guid studentId, Guid courseId)
        {
            throw new NotImplementedException();
        }
        public Task<int> GetEnrollmentCountForCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
  
}
