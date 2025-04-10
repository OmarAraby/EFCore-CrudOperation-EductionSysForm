

using EducationSysProject.Context;
using EducationSysProject.Data.Models;

namespace EducationSysProject.Data.Repositories.CourseRepository
{
   public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(EducationSysContext context) : base(context)
        {
        }
        public Task<IEnumerable<Course>> GetCoursesWithStudentsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Course>> GetCoursesWithSessionsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Course?> GetCourseWithStudentsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Course?> GetCourseWithSessionsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Course>> GetCoursesByDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Course>> GetCoursesByInstructorAsync(Guid instructorId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Course>> SearchCoursesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
   
}
