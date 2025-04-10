

using EducationSysProject.Configurations;
using EducationSysProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationSysProject.Context
{
    public class EducationSysContext : DbContext
    {
        public EducationSysContext()
        {
        }
        public EducationSysContext(DbContextOptions<EducationSysContext> options) : base(options)
        {
        }

        #region Db Connection

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=OMAR-ARaby\\SQLEXPRESS;DataBase=EducationSys;Trusted_Connection=true;TrustServerCertificate=true");
        }
        #endregion

        #region Tables

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseSession> CourseSessions { get; set; }
        public DbSet<CourseSessionAttendance> CourseSessionAttendances { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        #endregion


        #region Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new DepartmentConfig());
            modelBuilder.ApplyConfiguration(new InstructorConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new CourseSessionConfig());
            modelBuilder.ApplyConfiguration(new CourseSessionAttendanceConfig());
            modelBuilder.ApplyConfiguration(new CourseStudentConfig());


            #region Seeding
            // Create Guids for each entity
            var departmentIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000000"),
                Guid.Parse("00000002-0000-0000-0000-000000000000"),
                Guid.Parse("00000003-0000-0000-0000-000000000000"),
                Guid.Parse("00000004-0000-0000-0000-000000000000"),

            };

            var instructorIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000001"),
                Guid.Parse("00000002-0000-0000-0000-000000000001"),
                Guid.Parse("00000003-0000-0000-0000-000000000001")
            };

            var courseIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000002"),
                Guid.Parse("00000002-0000-0000-0000-000000000002"),
                Guid.Parse("00000003-0000-0000-0000-000000000002")
            };

            var studentIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000003"),
                Guid.Parse("00000002-0000-0000-0000-000000000003"),
                Guid.Parse("00000003-0000-0000-0000-000000000003"),
                Guid.Parse("00000004-0000-0000-0000-000000000003"),
                Guid.Parse("00000005-0000-0000-0000-000000000003")
            };
            var sessionIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000004"),
                Guid.Parse("00000002-0000-0000-0000-000000000004"),
                Guid.Parse("00000003-0000-0000-0000-000000000004")
            };

            var attendanceIds = new Guid[]
            {
                Guid.Parse("00000001-0000-0000-0000-000000000005"),
                Guid.Parse("00000002-0000-0000-0000-000000000005"),
                Guid.Parse("00000003-0000-0000-0000-000000000005")
            };


            var _department = new List<Department>()
            {
                new Department(){DepartmentID=departmentIds[0] , ManagerID = instructorIds[0], Name="Computer Science" ,Location="Lab02" },
                new Department
                {
                    DepartmentID = departmentIds[1],
                    ManagerID = instructorIds[1],
                    Name = "Information Technology",
                    Location = "Building B"
                },
                new Department
                {
                    DepartmentID = departmentIds[2],
                    ManagerID = instructorIds[1],
                    Name = "SD",
                    Location = "Building B"
                },
                new Department
                {
                    DepartmentID = departmentIds[3],
                    ManagerID = instructorIds[1],
                    Name = "UI",
                    Location = "Lab01"
                }

            };

            var _instructor = new List<Instructor>()
            {
                 new Instructor
                {
                    ID = instructorIds[0],
                    DepartmentID = departmentIds[0],
                    FirstName = "Mohamed",
                    LastName = "Hatem",
                    Email = "Hatem@example.com"
                },
                new Instructor
                {
                    ID = instructorIds[1],
                    DepartmentID = departmentIds[1],
                    FirstName = "Sarah",
                    LastName = "Magdy",
                    Email = "sarah@example.com"
                },
                new Instructor
                {
                    ID = instructorIds[2],
                    DepartmentID = departmentIds[0],
                    FirstName = "Youssef",
                    LastName = "Eng",
                    Email = "joe@example.com"
                }
            };

            var _course = new List<Course>()
            {
                new Course
                {
                    ID = courseIds[0],
                    Name = "C#",
                    Duration = 3,
                    DepartmentID = departmentIds[0],
                    InstructorID = instructorIds[0]
                },
                new Course
                {
                    ID = courseIds[1],
                    Name = "Java",
                    Duration = 3,
                    DepartmentID = departmentIds[1],
                    InstructorID = instructorIds[1]
                },
                new Course
                {
                    ID = courseIds[2],
                    Name = "Python",
                    Duration = 3,
                    DepartmentID = departmentIds[0],
                    InstructorID = instructorIds[0]
                }
            };

            var _student = new List<Student>()
            {
                 new Student
                {
                    ID = studentIds[0],
                    FirstName = "Omar",
                    LastName = "Araby",
                    Phone = "01128285281"
                },
                 new Student
                {
                    ID = studentIds[1],
                    FirstName = "Aly",
                    LastName = "Araby",
                    Phone = "01128285281"
                },
                    new Student
                    {
                        ID = studentIds[2],
                        FirstName = "Ahmed",
                        LastName = "Araby",
                        Phone = "01128285281"
                    },
                    new Student
                    {
                        ID = studentIds[3],
                        FirstName = "Mohamed",
                        LastName = "Araby",
                        Phone = "01128285281"
                    }
            };

            var _courseSession = new List<CourseSession>()
            {
                new CourseSession
                {
                    ID = sessionIds[0],
                    CourseID = courseIds[0],
                    InstructorID = instructorIds[0],
                    Date =new DateTime(2025, 1, 16, 14, 0, 0),
                    Title = "Variables and Data Types"
                },
                new CourseSession
                {
                    ID = sessionIds[1],
                    CourseID = courseIds[1],
                    InstructorID = instructorIds[1],
                    Date = new DateTime(2025, 1, 17, 14, 0, 0),
                    Title = "Entity Relationship Diagrams"
                },
                new CourseSession
                {
                    ID = sessionIds[2],
                    CourseID = courseIds[2],
                    InstructorID = instructorIds[2],
                    Date = new DateTime(2025, 1, 15, 14, 0, 0),
                    Title = "HTML and CSS Basics"
                }
            };

            var _courseStudent = new List<CourseStudent>()
            {
                new CourseStudent { CourseID = courseIds[0], StudentID = studentIds[0] },
                new CourseStudent { CourseID = courseIds[0], StudentID = studentIds[1] },
                new CourseStudent { CourseID = courseIds[1], StudentID = studentIds[1] },
                new CourseStudent { CourseID = courseIds[1], StudentID = studentIds[2] },
                new CourseStudent { CourseID = courseIds[2], StudentID = studentIds[0] },
                new CourseStudent { CourseID = courseIds[2], StudentID = studentIds[3] }
            };

            var _courseSessionAttendance = new List<CourseSessionAttendance>()
            {
                new CourseSessionAttendance
                {
                    ID = attendanceIds[0],
                    CourseSessionID = sessionIds[0],
                    StudentID = studentIds[0],
                    Grade = 85,
                    Notes = "Good participation"
                },
                new CourseSessionAttendance
                {
                    ID = attendanceIds[1],
                    CourseSessionID = sessionIds[1],
                    StudentID = studentIds[1],
                    Grade = 90,
                    Notes = "Excellent work"
                },
                new CourseSessionAttendance
                {
                    ID = attendanceIds[2],
                    CourseSessionID = sessionIds[2],
                    StudentID = studentIds[3],
                    Grade = 78,
                    Notes = "Needs improvement on project"
                }
            };


            modelBuilder.Entity<Department>()
                .HasData(_department);
            modelBuilder.Entity<Instructor>()
              .HasData(_instructor);
            modelBuilder.Entity<Course>()
                .HasData(_course);
            modelBuilder.Entity<Student>()
                .HasData(_student);
            modelBuilder.Entity<CourseSession>()
                .HasData(_courseSession);
            modelBuilder.Entity<CourseStudent>()
                .HasData(_courseStudent);
            modelBuilder.Entity<CourseSessionAttendance>()
                .HasData(_courseSessionAttendance);
            #endregion

            base.OnModelCreating(modelBuilder);


        }
        #endregion
    }
}
