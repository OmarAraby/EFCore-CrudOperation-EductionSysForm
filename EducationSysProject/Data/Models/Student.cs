namespace EducationSysProject.Data.Models
{
   public class Student
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; } = string.Empty;


            // relation --> navigation property

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<CourseSessionAttendance> Attendances { get; set; }
    }
    }
