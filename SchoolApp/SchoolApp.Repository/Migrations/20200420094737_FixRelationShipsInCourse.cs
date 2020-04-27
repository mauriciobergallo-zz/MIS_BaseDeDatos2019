using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class FixRelationShipsInCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_headerTeacherid",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subjects_subjectid",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrolledInCourses_Courses_CourseDtoid",
                table: "StudentEnrolledInCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseDtoid",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseDtoid",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrolledInCourses_CourseDtoid",
                table: "StudentEnrolledInCourses");

            migrationBuilder.DropColumn(
                name: "CourseDtoid",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseDtoid",
                table: "StudentEnrolledInCourses");

            migrationBuilder.RenameColumn(
                name: "subjectid",
                table: "Courses",
                newName: "subjectId");

            migrationBuilder.RenameColumn(
                name: "headerTeacherid",
                table: "Courses",
                newName: "headerTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_subjectid",
                table: "Courses",
                newName: "IX_Courses_subjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_headerTeacherid",
                table: "Courses",
                newName: "IX_Courses_headerTeacherId");

            migrationBuilder.AlterColumn<Guid>(
                name: "subjectId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "headerTeacherId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "schoolId",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CourseSecondaryTeachers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    courseId = table.Column<Guid>(nullable: false),
                    secondaryTeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSecondaryTeachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseSecondaryTeachers_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSecondaryTeachers_Teachers_secondaryTeacherId",
                        column: x => x.secondaryTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudentsEnrolled",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    courseId = table.Column<Guid>(nullable: false),
                    studentEnrolledId = table.Column<Guid>(nullable: false)
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
                        name: "FK_CourseStudentsEnrolled_StudentEnrolledInCourses_studentEnro~",
                        column: x => x.studentEnrolledId,
                        principalTable: "StudentEnrolledInCourses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSecondaryTeachers_courseId",
                table: "CourseSecondaryTeachers",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSecondaryTeachers_secondaryTeacherId",
                table: "CourseSecondaryTeachers",
                column: "secondaryTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentsEnrolled_courseId",
                table: "CourseStudentsEnrolled",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentsEnrolled_studentEnrolledId",
                table: "CourseStudentsEnrolled",
                column: "studentEnrolledId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_headerTeacherId",
                table: "Courses",
                column: "headerTeacherId",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subjects_subjectId",
                table: "Courses",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_headerTeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Subjects_subjectId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseSecondaryTeachers");

            migrationBuilder.DropTable(
                name: "CourseStudentsEnrolled");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "subjectId",
                table: "Courses",
                newName: "subjectid");

            migrationBuilder.RenameColumn(
                name: "headerTeacherId",
                table: "Courses",
                newName: "headerTeacherid");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_subjectId",
                table: "Courses",
                newName: "IX_Courses_subjectid");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_headerTeacherId",
                table: "Courses",
                newName: "IX_Courses_headerTeacherid");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseDtoid",
                table: "Teachers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseDtoid",
                table: "StudentEnrolledInCourses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "subjectid",
                table: "Courses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "headerTeacherid",
                table: "Courses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseDtoid",
                table: "Teachers",
                column: "CourseDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_CourseDtoid",
                table: "StudentEnrolledInCourses",
                column: "CourseDtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_headerTeacherid",
                table: "Courses",
                column: "headerTeacherid",
                principalTable: "Teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Subjects_subjectid",
                table: "Courses",
                column: "subjectid",
                principalTable: "Subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrolledInCourses_Courses_CourseDtoid",
                table: "StudentEnrolledInCourses",
                column: "CourseDtoid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseDtoid",
                table: "Teachers",
                column: "CourseDtoid",
                principalTable: "Courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
