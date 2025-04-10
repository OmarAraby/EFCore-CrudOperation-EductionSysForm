using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationSysProject.Migrations
{
    /// <inheritdoc />
    public partial class Handlesomeconstraintsinconfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSessionAttendances_CourseSessions_CourseSessionID",
                table: "CourseSessionAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSessionAttendances_Students_StudentID",
                table: "CourseSessionAttendances");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessionAttendances_CourseSessions_CourseSessionID",
                table: "CourseSessionAttendances",
                column: "CourseSessionID",
                principalTable: "CourseSessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessionAttendances_Students_StudentID",
                table: "CourseSessionAttendances",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSessionAttendances_CourseSessions_CourseSessionID",
                table: "CourseSessionAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSessionAttendances_Students_StudentID",
                table: "CourseSessionAttendances");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessionAttendances_CourseSessions_CourseSessionID",
                table: "CourseSessionAttendances",
                column: "CourseSessionID",
                principalTable: "CourseSessions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSessionAttendances_Students_StudentID",
                table: "CourseSessionAttendances",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
