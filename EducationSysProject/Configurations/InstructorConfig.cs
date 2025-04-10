using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSysProject.Configurations
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            //throw new NotImplementedException();
            // pk
            builder.HasKey(i => i.ID);

            builder.Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(i => i.Email)
                .HasMaxLength(50)
                .IsUnicode();

            // relation --> navigation property
            // one to many
            builder.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorID)  // fk in Course
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.CourseSessions)
                .WithOne(cs => cs.Instructor)
                .HasForeignKey(cs => cs.InstructorID) // fk in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentID) // fk in Instructor
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
