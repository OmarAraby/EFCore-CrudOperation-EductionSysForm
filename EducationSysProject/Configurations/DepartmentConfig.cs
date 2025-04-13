

using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationSysProject.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
           //pk
           builder.HasKey(d=>d.DepartmentID);

           builder.Property(d => d.Name)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode();

            builder.Property(d => d.Location)
                .HasMaxLength(50)
                .IsUnicode();


            // relation --> navigation property
            // one to many
            builder.HasMany(d => d.Courses)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentID)  // fk in Course
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(d => d.Instructors)
                .WithOne(i => i.Department)
                .HasForeignKey(i => i.DepartmentID) // fk in Instructor
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
