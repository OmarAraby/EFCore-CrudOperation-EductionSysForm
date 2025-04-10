using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationSysProject.Migrations
{
    /// <inheritdoc />
    public partial class ondeletecascadeoncoursestudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CourseID",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Students_StudentID",
                table: "CourseStudents");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CourseID",
                table: "CourseStudents",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Students_StudentID",
                table: "CourseStudents",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Courses_CourseID",
                table: "CourseStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudents_Students_StudentID",
                table: "CourseStudents");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Courses_CourseID",
                table: "CourseStudents",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudents_Students_StudentID",
                table: "CourseStudents",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
