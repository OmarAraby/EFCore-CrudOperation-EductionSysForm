namespace EducationSysProject.Data.Models
{
    public class Instructor
    {
        public Guid ID { get; set; }
        public Guid? DepartmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        // relation --> navigation property

        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
    }
}
