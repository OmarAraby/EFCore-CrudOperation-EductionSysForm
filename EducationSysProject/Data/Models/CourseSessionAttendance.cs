namespace EducationSysProject.Data.Models
{
   public class CourseSessionAttendance
    {
        public Guid ID { get; set; }
        public Guid CourseSessionID { get; set; }
        public Guid StudentID { get; set; }
        public int Grade { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public virtual CourseSession CourseSession { get; set; }
        public virtual Student Student { get; set; }

    }
}
