namespace EducationSysProject.Data.Models
{
   public class Department
    {
        public Guid DepartmentID { get; set; }
        public Guid ManagerID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // relation --> navigation property
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
