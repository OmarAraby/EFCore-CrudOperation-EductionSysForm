

using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationSysProject.Configurations
{
    public class CourseSessionConfig : IEntityTypeConfiguration<CourseSession>
    {
        public void Configure(EntityTypeBuilder<CourseSession> builder)
        {
            // pk
            builder.HasKey(cs => cs.ID);

            builder.Property(cs => cs.Date)
                .IsRequired();

            builder.Property(cs=>cs.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();


            // relation --> navigation property

            builder.HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSessions)
                .HasForeignKey(cs => cs.CourseID) // fk in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cs => cs.Instructor)
                .WithMany(i => i.CourseSessions)
                .HasForeignKey(cs => cs.InstructorID) // fk in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(cs => cs.Attendances)
                .WithOne(ca => ca.CourseSession)
                .HasForeignKey(ca => ca.CourseSessionID) // fk in CourseSessionAttendance
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
