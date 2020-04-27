using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class RemovedStudentEnrolled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentsEnrolled_StudentEnrolledInCourses_studentEnro~",
                table: "CourseStudentsEnrolled");

            migrationBuilder.DropTable(
                name: "StudentEnrolledInCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentsEnrolled_Enrollments_studentEnrolledId",
                table: "CourseStudentsEnrolled",
                column: "studentEnrolledId",
                principalTable: "Enrollments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentsEnrolled_Enrollments_studentEnrolledId",
                table: "CourseStudentsEnrolled");

            migrationBuilder.CreateTable(
                name: "StudentEnrolledInCourses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enrollmentid = table.Column<Guid>(type: "uuid", nullable: true),
                    studentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolledInCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolledInCourses_Enrollments_enrollmentid",
                        column: x => x.enrollmentid,
                        principalTable: "Enrollments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrolledInCourses_Students_studentid",
                        column: x => x.studentid,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_enrollmentid",
                table: "StudentEnrolledInCourses",
                column: "enrollmentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_studentid",
                table: "StudentEnrolledInCourses",
                column: "studentid");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentsEnrolled_StudentEnrolledInCourses_studentEnro~",
                table: "CourseStudentsEnrolled",
                column: "studentEnrolledId",
                principalTable: "StudentEnrolledInCourses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
