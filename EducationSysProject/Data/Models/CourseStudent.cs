namespace EducationSysProject.Data.Models
{
   public class CourseStudent
    {
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }
      
        // relation --> navigation property
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
