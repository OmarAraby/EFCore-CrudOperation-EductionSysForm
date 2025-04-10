using EducationSysProject.Context;
using EducationSysProject.Data.Models;


namespace EducationSysProject.Data.Repositories.CourseSessionAttendanceRepository
{
    public class CourseSessionAttendanceRepository : BaseRepository<CourseSessionAttendance>, ICourseSessionAttendanceRepository
    {
        public CourseSessionAttendanceRepository(EducationSysContext context) : base(context)
        {
        }
        public Task<IEnumerable<CourseSessionAttendance>> GetAttendanceBySessionAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseSessionAttendance>> GetAttendanceByStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseSessionAttendance?> GetAttendanceRecordAsync(Guid sessionId, Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetAverageGradeForSessionAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetAverageGradeForStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}
