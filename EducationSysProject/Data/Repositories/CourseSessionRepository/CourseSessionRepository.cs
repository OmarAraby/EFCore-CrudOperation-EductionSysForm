using EducationSysProject.Context;
using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.CourseSessionRepository
{
    public class CourseSessionRepository : BaseRepository<CourseSession>, ICourseSessionRepository
    {
        public CourseSessionRepository(EducationSysContext context) : base(context)
        {
        }

        public Task<IEnumerable<CourseSession>> GetSessionsByCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseSession>> GetSessionsByDateRangeAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseSession>> GetSessionsByInstructorAsync(Guid instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseSession>> GetSessionsWithAttendanceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseSession?> GetSessionWithAttendanceAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseSession>> GetUpcomingSessionsAsync(DateTime fromDate)
        {
            throw new NotImplementedException();
        }
    }
}
