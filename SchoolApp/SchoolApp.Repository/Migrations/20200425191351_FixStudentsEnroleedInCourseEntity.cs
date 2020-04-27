using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class FixStudentsEnroleedInCourseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudentsEnrolled");

            migrationBuilder.CreateTable(
                name: "StudentEnrolledInCourseDto",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    courseId = table.Column<Guid>(nullable: false),
                    studentEnrolledId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolledInCourseDto", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolledInCourseDto_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolledInCourseDto_Enrollments_studentEnrolledId",
                        column: x => x.studentEnrolledId,
                        principalTable: "Enrollments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourseDto_courseId",
                table: "StudentEnrolledInCourseDto",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourseDto_studentEnrolledId",
                table: "StudentEnrolledInCourseDto",
                column: "studentEnrolledId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentEnrolledInCourseDto");

            migrationBuilder.CreateTable(
                name: "CourseStudentsEnrolled",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    courseId = table.Column<Guid>(type: "uuid", nullable: false),
                    studentEnrolledId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentsEnrolled", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseStudentsEnrolled_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentsEnrolled_Enrollments_studentEnrolledId",
                        column: x => x.studentEnrolledId,
                        principalTable: "Enrollments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentsEnrolled_courseId",
                table: "CourseStudentsEnrolled",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentsEnrolled_studentEnrolledId",
                table: "CourseStudentsEnrolled",
                column: "studentEnrolledId");
        }
    }
}
