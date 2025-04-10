using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationSysProject.Configurations
{
    public class CourseStudentConfig : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            // Composite Key
            builder.HasKey(cs => new { cs.CourseID, cs.StudentID });

            // Relationships
            builder.HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseID) // fk in CourseStudent
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StudentID)  // fk in CourseStudent
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}