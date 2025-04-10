using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationSysProject.Configurations
{
    public class CourseSessionAttendanceConfig : IEntityTypeConfiguration<CourseSessionAttendance>
    {
        public void Configure(EntityTypeBuilder<CourseSessionAttendance> builder)
        {
            // Primary Key
            builder.HasKey(csa => csa.ID);

            
            builder.Property(csa => csa.Grade);

            builder.Property(csa => csa.Notes)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(csa => csa.CourseSession)
                .WithMany(cs => cs.Attendances)
                .HasForeignKey(csa => csa.CourseSessionID) // fk in CourseSessionAttendance
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(csa => csa.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(csa => csa.StudentID) // fk in CourseSessionAttendance
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}