using EducationSysProject.Data.Models;

namespace EducationSysProject.Data.Repositories.CourseRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetCoursesWithStudentsAsync();
        Task<IEnumerable<Course>> GetCoursesWithSessionsAsync();
        Task<Course?> GetCourseWithStudentsAsync(Guid id);
        Task<Course?> GetCourseWithSessionsAsync(Guid id);
        Task<IEnumerable<Course>> GetCoursesByDepartmentAsync(Guid departmentId);
        Task<IEnumerable<Course>> GetCoursesByInstructorAsync(Guid instructorId);
        Task<IEnumerable<Course>> SearchCoursesByNameAsync(string name);
    }
}
