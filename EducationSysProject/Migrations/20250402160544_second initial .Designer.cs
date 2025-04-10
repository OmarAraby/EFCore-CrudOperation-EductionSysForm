﻿// <auto-generated />
using System;
using EducationSysProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationSysProject.Migrations
{
    [DbContext(typeof(EducationSysContext))]
    [Migration("20250402160544_second initial ")]
    partial class secondinitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducationSysProject.Data.Models.Course", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<Guid>("InstructorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            ID = new Guid("00000001-0000-0000-0000-000000000002"),
                            DepartmentID = new Guid("00000001-0000-0000-0000-000000000000"),
                            Duration = 3,
                            InstructorID = new Guid("00000001-0000-0000-0000-000000000001"),
                            Name = "C#"
                        },
                        new
                        {
                            ID = new Guid("00000002-0000-0000-0000-000000000002"),
                            DepartmentID = new Guid("00000002-0000-0000-0000-000000000000"),
                            Duration = 3,
                            InstructorID = new Guid("00000002-0000-0000-0000-000000000001"),
                            Name = "Java"
                        },
                        new
                        {
                            ID = new Guid("00000003-0000-0000-0000-000000000002"),
                            DepartmentID = new Guid("00000001-0000-0000-0000-000000000000"),
                            Duration = 3,
                            InstructorID = new Guid("00000001-0000-0000-0000-000000000001"),
                            Name = "Python"
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseSession", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InstructorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseSessions");

                    b.HasData(
                        new
                        {
                            ID = new Guid("00000001-0000-0000-0000-000000000004"),
                            CourseID = new Guid("00000001-0000-0000-0000-000000000002"),
                            Date = new DateTime(2025, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            InstructorID = new Guid("00000001-0000-0000-0000-000000000001"),
                            Title = "Variables and Data Types"
                        },
                        new
                        {
                            ID = new Guid("00000002-0000-0000-0000-000000000004"),
                            CourseID = new Guid("00000002-0000-0000-0000-000000000002"),
                            Date = new DateTime(2025, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            InstructorID = new Guid("00000002-0000-0000-0000-000000000001"),
                            Title = "Entity Relationship Diagrams"
                        },
                        new
                        {
                            ID = new Guid("00000003-0000-0000-0000-000000000004"),
                            CourseID = new Guid("00000003-0000-0000-0000-000000000002"),
                            Date = new DateTime(2025, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            InstructorID = new Guid("00000003-0000-0000-0000-000000000001"),
                            Title = "HTML and CSS Basics"
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseSessionAttendance", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseSessionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CourseSessionID");

                    b.HasIndex("StudentID");

                    b.ToTable("CourseSessionAttendances");

                    b.HasData(
                        new
                        {
                            ID = new Guid("00000001-0000-0000-0000-000000000005"),
                            CourseSessionID = new Guid("00000001-0000-0000-0000-000000000004"),
                            Grade = 85,
                            Notes = "Good participation",
                            StudentID = new Guid("00000001-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            ID = new Guid("00000002-0000-0000-0000-000000000005"),
                            CourseSessionID = new Guid("00000002-0000-0000-0000-000000000004"),
                            Grade = 90,
                            Notes = "Excellent work",
                            StudentID = new Guid("00000002-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            ID = new Guid("00000003-0000-0000-0000-000000000005"),
                            CourseSessionID = new Guid("00000003-0000-0000-0000-000000000004"),
                            Grade = 78,
                            Notes = "Needs improvement on project",
                            StudentID = new Guid("00000004-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseStudent", b =>
                {
                    b.Property<Guid>("CourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CourseID", "StudentID");

                    b.HasIndex("StudentID");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            CourseID = new Guid("00000001-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000001-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            CourseID = new Guid("00000001-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000002-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            CourseID = new Guid("00000002-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000002-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            CourseID = new Guid("00000002-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000003-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            CourseID = new Guid("00000003-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000001-0000-0000-0000-000000000003")
                        },
                        new
                        {
                            CourseID = new Guid("00000003-0000-0000-0000-000000000002"),
                            StudentID = new Guid("00000004-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Department", b =>
                {
                    b.Property<Guid>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ManagerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = new Guid("00000001-0000-0000-0000-000000000000"),
                            Location = "Lab02",
                            ManagerID = new Guid("00000001-0000-0000-0000-000000000001"),
                            Name = "Computer Science"
                        },
                        new
                        {
                            DepartmentID = new Guid("00000002-0000-0000-0000-000000000000"),
                            Location = "Building B",
                            ManagerID = new Guid("00000002-0000-0000-0000-000000000001"),
                            Name = "Information Technology"
                        },
                        new
                        {
                            DepartmentID = new Guid("00000003-0000-0000-0000-000000000000"),
                            Location = "Building B",
                            ManagerID = new Guid("00000002-0000-0000-0000-000000000001"),
                            Name = "SD"
                        },
                        new
                        {
                            DepartmentID = new Guid("00000004-0000-0000-0000-000000000000"),
                            Location = "Lab01",
                            ManagerID = new Guid("00000002-0000-0000-0000-000000000001"),
                            Name = "UI"
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Instructor", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            ID = new Guid("00000001-0000-0000-0000-000000000001"),
                            DepartmentID = new Guid("00000001-0000-0000-0000-000000000000"),
                            Email = "Hatem@example.com",
                            FirstName = "Mohamed",
                            LastName = "Hatem"
                        },
                        new
                        {
                            ID = new Guid("00000002-0000-0000-0000-000000000001"),
                            DepartmentID = new Guid("00000002-0000-0000-0000-000000000000"),
                            Email = "sarah@example.com",
                            FirstName = "Sarah",
                            LastName = "Magdy"
                        },
                        new
                        {
                            ID = new Guid("00000003-0000-0000-0000-000000000001"),
                            DepartmentID = new Guid("00000001-0000-0000-0000-000000000000"),
                            Email = "joe@example.com",
                            FirstName = "Youssef",
                            LastName = "Eng"
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Student", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            ID = new Guid("00000001-0000-0000-0000-000000000003"),
                            FirstName = "Omar",
                            LastName = "Araby",
                            Phone = "01128285281"
                        },
                        new
                        {
                            ID = new Guid("00000002-0000-0000-0000-000000000003"),
                            FirstName = "Aly",
                            LastName = "Araby",
                            Phone = "01128285281"
                        },
                        new
                        {
                            ID = new Guid("00000003-0000-0000-0000-000000000003"),
                            FirstName = "Ahmed",
                            LastName = "Araby",
                            Phone = "01128285281"
                        },
                        new
                        {
                            ID = new Guid("00000004-0000-0000-0000-000000000003"),
                            FirstName = "Mohamed",
                            LastName = "Araby",
                            Phone = "01128285281"
                        });
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Course", b =>
                {
                    b.HasOne("EducationSysProject.Data.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationSysProject.Data.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseSession", b =>
                {
                    b.HasOne("EducationSysProject.Data.Models.Course", "Course")
                        .WithMany("CourseSessions")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationSysProject.Data.Models.Instructor", "Instructor")
                        .WithMany("CourseSessions")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseSessionAttendance", b =>
                {
                    b.HasOne("EducationSysProject.Data.Models.CourseSession", "CourseSession")
                        .WithMany("Attendances")
                        .HasForeignKey("CourseSessionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationSysProject.Data.Models.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseSession");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseStudent", b =>
                {
                    b.HasOne("EducationSysProject.Data.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationSysProject.Data.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Instructor", b =>
                {
                    b.HasOne("EducationSysProject.Data.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Course", b =>
                {
                    b.Navigation("CourseSessions");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.CourseSession", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Instructor", b =>
                {
                    b.Navigation("CourseSessions");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EducationSysProject.Data.Models.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("CourseStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
