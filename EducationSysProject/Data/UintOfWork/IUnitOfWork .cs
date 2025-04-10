

using EducationSysProject.Data.Repositories.CourseRepository;
using EducationSysProject.Data.Repositories.CourseSessionAttendanceRepository;
using EducationSysProject.Data.Repositories.CourseSessionRepository;
using EducationSysProject.Data.Repositories.CourseStudentRepository;
using EducationSysProject.Data.Repositories.DepartmentRepository;
using EducationSysProject.Data.Repositories.InstructorRepository;
using EducationSysProject.Data.Repositories.StudentRepository;

namespace EducationSysProject.Data.UintOfWork
{
    
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IDepartmentRepository Departments { get; }
        IInstructorRepository Instructors { get; }
        ICourseRepository Courses { get; }
        ICourseSessionRepository CourseSessions { get; }
        ICourseStudentRepository CourseStudents { get; }
        ICourseSessionAttendanceRepository CourseSessionAttendances { get; }
        Task<int> CommitAsync();
    }
}
