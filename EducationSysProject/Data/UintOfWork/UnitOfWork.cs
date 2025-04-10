using EducationSysProject.Context;
using EducationSysProject.Data.Repositories.CourseRepository;
using EducationSysProject.Data.Repositories.CourseSessionAttendanceRepository;
using EducationSysProject.Data.Repositories.CourseSessionRepository;
using EducationSysProject.Data.Repositories.CourseStudentRepository;
using EducationSysProject.Data.Repositories.DepartmentRepository;
using EducationSysProject.Data.Repositories.InstructorRepository;
using EducationSysProject.Data.Repositories.StudentRepository;
using EducationSysProject.Data.UintOfWork;

namespace EducationSysProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationSysContext _context;

        public UnitOfWork(EducationSysContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Departments = new DepartmentRepository(_context);
            Instructors = new InstructorRepository(_context);
            Courses = new CourseRepository(_context);
            CourseSessions = new CourseSessionRepository(_context);
            CourseStudents = new CourseStudentRepository(_context);
            CourseSessionAttendances = new CourseSessionAttendanceRepository(_context);
        }

        public IStudentRepository Students { get; }
        public IDepartmentRepository Departments { get; }
        public IInstructorRepository Instructors { get; }
        public ICourseRepository Courses { get; }
        public ICourseSessionRepository CourseSessions { get; }
        public ICourseStudentRepository CourseStudents { get; }
        public ICourseSessionAttendanceRepository CourseSessionAttendances { get; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this); // Prevents redundant finalizer calls

        }
    }
}