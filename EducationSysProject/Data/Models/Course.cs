namespace EducationSysProject.Data.Models
{
   public class Course
    {
        public Guid ID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? InstructorID { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }

        // relation --> navigation property
        public virtual Department Department { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }

    }
}
