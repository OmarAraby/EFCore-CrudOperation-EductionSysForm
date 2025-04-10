using EducationSysProject.Data.Models;


namespace EducationSysProject.Data.Repositories.InstructorRepository
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<IEnumerable<Instructor>> GetInstructorsWithCoursesAsync();
        Task<Instructor?> GetInstructorWithCoursesAsync(Guid id);
        Task<IEnumerable<Instructor>> GetInstructorsByDepartmentAsync(Guid departmentId);
        Task<IEnumerable<Instructor>> SearchInstructorsByNameAsync(string name);
    }
}
