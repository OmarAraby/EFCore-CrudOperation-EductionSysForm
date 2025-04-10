using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.CourseSessionRepository
{
    public interface ICourseSessionRepository : IRepository<CourseSession>
    {
        Task<IEnumerable<CourseSession>> GetSessionsWithAttendanceAsync();
        Task<CourseSession?> GetSessionWithAttendanceAsync(Guid id);
        Task<IEnumerable<CourseSession>> GetSessionsByCourseAsync(Guid courseId);
        Task<IEnumerable<CourseSession>> GetSessionsByInstructorAsync(Guid instructorId);
        Task<IEnumerable<CourseSession>> GetUpcomingSessionsAsync(DateTime fromDate);
        Task<IEnumerable<CourseSession>> GetSessionsByDateRangeAsync(DateTime start, DateTime end);
    }
}
