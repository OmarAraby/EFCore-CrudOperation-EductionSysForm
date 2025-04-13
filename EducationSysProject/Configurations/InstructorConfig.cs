using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
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

        // Relations
        builder.HasMany(i => i.Courses)
            .WithOne(c => c.Instructor)
            .HasForeignKey(c => c.InstructorID)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(i => i.CourseSessions)
            .WithOne(cs => cs.Instructor)
            .HasForeignKey(cs => cs.InstructorID)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(i => i.Department)
            .WithMany(d => d.Instructors)
            .HasForeignKey(i => i.DepartmentID)
            .OnDelete(DeleteBehavior.SetNull); // تغيير من Restrict إلى SetNull
    }
}