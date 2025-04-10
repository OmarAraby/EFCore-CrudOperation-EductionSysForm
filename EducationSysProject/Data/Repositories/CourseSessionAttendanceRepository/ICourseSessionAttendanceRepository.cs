using EducationSysProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Data.Repositories.CourseSessionAttendanceRepository
{
    public interface ICourseSessionAttendanceRepository : IRepository<CourseSessionAttendance>
    {
        Task<IEnumerable<CourseSessionAttendance>> GetAttendanceBySessionAsync(Guid sessionId);
        Task<IEnumerable<CourseSessionAttendance>> GetAttendanceByStudentAsync(Guid studentId);
        Task<CourseSessionAttendance?> GetAttendanceRecordAsync(Guid sessionId, Guid studentId);
        Task<double> GetAverageGradeForSessionAsync(Guid sessionId);
        Task<double> GetAverageGradeForStudentAsync(Guid studentId);
    }
}
