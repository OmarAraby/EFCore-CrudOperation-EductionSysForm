

using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationSysProject.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            //pk
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(c => c.Duration)
                .IsRequired();

            // relation --> navigation property
            // one to many
            builder.HasMany(c => c.CourseStudents)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseID)  // fk in CourseStudent
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CourseSessions)
                .WithOne(cs => cs.Course)
                .HasForeignKey(cs => cs.CourseID) // fk in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentID) // fk in Course
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorID) // fk in Course
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
