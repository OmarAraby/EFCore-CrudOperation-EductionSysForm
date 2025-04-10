using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationSysProject.Migrations
{
    /// <inheritdoc />
    public partial class secondinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSessions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseSessions_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSessions_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSessionAttendances",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseSessionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessionAttendances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseSessionAttendances_CourseSessions_CourseSessionID",
                        column: x => x.CourseSessionID,
                        principalTable: "CourseSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSessionAttendances_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Location", "ManagerID", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000000"), "Lab02", new Guid("00000001-0000-0000-0000-000000000001"), "Computer Science" },
                    { new Guid("00000002-0000-0000-0000-000000000000"), "Building B", new Guid("00000002-0000-0000-0000-000000000001"), "Information Technology" },
                    { new Guid("00000003-0000-0000-0000-000000000000"), "Building B", new Guid("00000002-0000-0000-0000-000000000001"), "SD" },
                    { new Guid("00000004-0000-0000-0000-000000000000"), "Lab01", new Guid("00000002-0000-0000-0000-000000000001"), "UI" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000003"), "Omar", "Araby", "01128285281" },
                    { new Guid("00000002-0000-0000-0000-000000000003"), "Aly", "Araby", "01128285281" },
                    { new Guid("00000003-0000-0000-0000-000000000003"), "Ahmed", "Araby", "01128285281" },
                    { new Guid("00000004-0000-0000-0000-000000000003"), "Mohamed", "Araby", "01128285281" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "DepartmentID", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000001"), new Guid("00000001-0000-0000-0000-000000000000"), "Hatem@example.com", "Mohamed", "Hatem" },
                    { new Guid("00000002-0000-0000-0000-000000000001"), new Guid("00000002-0000-0000-0000-000000000000"), "sarah@example.com", "Sarah", "Magdy" },
                    { new Guid("00000003-0000-0000-0000-000000000001"), new Guid("00000001-0000-0000-0000-000000000000"), "joe@example.com", "Youssef", "Eng" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "DepartmentID", "Duration", "InstructorID", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000002"), new Guid("00000001-0000-0000-0000-000000000000"), 3, new Guid("00000001-0000-0000-0000-000000000001"), "C#" },
                    { new Guid("00000002-0000-0000-0000-000000000002"), new Guid("00000002-0000-0000-0000-000000000000"), 3, new Guid("00000002-0000-0000-0000-000000000001"), "Java" },
                    { new Guid("00000003-0000-0000-0000-000000000002"), new Guid("00000001-0000-0000-0000-000000000000"), 3, new Guid("00000001-0000-0000-0000-000000000001"), "Python" }
                });

            migrationBuilder.InsertData(
                table: "CourseSessions",
                columns: new[] { "ID", "CourseID", "Date", "InstructorID", "Title" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000004"), new Guid("00000001-0000-0000-0000-000000000002"), new DateTime(2025, 1, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000001-0000-0000-0000-000000000001"), "Variables and Data Types" },
                    { new Guid("00000002-0000-0000-0000-000000000004"), new Guid("00000002-0000-0000-0000-000000000002"), new DateTime(2025, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000002-0000-0000-0000-000000000001"), "Entity Relationship Diagrams" },
                    { new Guid("00000003-0000-0000-0000-000000000004"), new Guid("00000003-0000-0000-0000-000000000002"), new DateTime(2025, 1, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000003-0000-0000-0000-000000000001"), "HTML and CSS Basics" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseID", "StudentID" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000002"), new Guid("00000001-0000-0000-0000-000000000003") },
                    { new Guid("00000001-0000-0000-0000-000000000002"), new Guid("00000002-0000-0000-0000-000000000003") },
                    { new Guid("00000002-0000-0000-0000-000000000002"), new Guid("00000002-0000-0000-0000-000000000003") },
                    { new Guid("00000002-0000-0000-0000-000000000002"), new Guid("00000003-0000-0000-0000-000000000003") },
                    { new Guid("00000003-0000-0000-0000-000000000002"), new Guid("00000001-0000-0000-0000-000000000003") },
                    { new Guid("00000003-0000-0000-0000-000000000002"), new Guid("00000004-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "CourseSessionAttendances",
                columns: new[] { "ID", "CourseSessionID", "Grade", "Notes", "StudentID" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000005"), new Guid("00000001-0000-0000-0000-000000000004"), 85, "Good participation", new Guid("00000001-0000-0000-0000-000000000003") },
                    { new Guid("00000002-0000-0000-0000-000000000005"), new Guid("00000002-0000-0000-0000-000000000004"), 90, "Excellent work", new Guid("00000002-0000-0000-0000-000000000003") },
                    { new Guid("00000003-0000-0000-0000-000000000005"), new Guid("00000003-0000-0000-0000-000000000004"), 78, "Needs improvement on project", new Guid("00000004-0000-0000-0000-000000000003") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorID",
                table: "Courses",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessionAttendances_CourseSessionID",
                table: "CourseSessionAttendances",
                column: "CourseSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessionAttendances_StudentID",
                table: "CourseSessionAttendances",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_CourseID",
                table: "CourseSessions",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_InstructorID",
                table: "CourseSessions",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentID",
                table: "CourseStudents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSessionAttendances");

            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "CourseSessions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
