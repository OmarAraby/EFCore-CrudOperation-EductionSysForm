namespace EducationSysProject.Data.Models
{
    public class CourseSession
    {
        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid? InstructorID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        // Navigation properties
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<CourseSessionAttendance> Attendances { get; set; }
    }
}
