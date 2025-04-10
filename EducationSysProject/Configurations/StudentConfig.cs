
using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EducationSysProject.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {


        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // pk
            builder.HasKey(s => s.ID);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(s => s.Phone)
                .HasMaxLength(15)
                .IsUnicode();

            //relation-- > navigation property
            //one to many
            builder.HasMany(s => s.CourseStudents)
                .WithOne(cs => cs.Student)
                .HasForeignKey(cs => cs.StudentID)  // fk in CourseStudent
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(s => s.Attendances)
                .WithOne(ca => ca.Student)
                .HasForeignKey(ca => ca.StudentID) // fk in CourseSessionAttendance
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
