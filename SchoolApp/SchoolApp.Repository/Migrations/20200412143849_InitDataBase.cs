using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    identificationNumber = table.Column<string>(nullable: true),
                    SchoolDtoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolDtoid",
                        column: x => x.SchoolDtoid,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    SchoolDtoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_Schools_SchoolDtoid",
                        column: x => x.SchoolDtoid,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    studentid = table.Column<Guid>(nullable: true),
                    studyPlanid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_studentid",
                        column: x => x.studentid,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_StudyPlans_studyPlanid",
                        column: x => x.studyPlanid,
                        principalTable: "StudyPlans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    studyPlanDtoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudyPlanDetails_StudyPlans_studyPlanDtoid",
                        column: x => x.studyPlanDtoid,
                        principalTable: "StudyPlans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    StudyPlanDetailDtoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subjects_StudyPlanDetails_StudyPlanDetailDtoid",
                        column: x => x.StudyPlanDetailDtoid,
                        principalTable: "StudyPlanDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrolledInCourses",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    studentid = table.Column<Guid>(nullable: true),
                    enrollmentid = table.Column<Guid>(nullable: true),
                    CourseDtoid = table.Column<Guid>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    identificationNumber = table.Column<string>(nullable: true),
                    teacherIdentification = table.Column<string>(nullable: true),
                    CourseDtoid = table.Column<Guid>(nullable: true),
                    SchoolDtoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_SchoolDtoid",
                        column: x => x.SchoolDtoid,
                        principalTable: "Schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    headerTeacherid = table.Column<Guid>(nullable: true),
                    subjectid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_headerTeacherid",
                        column: x => x.headerTeacherid,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Subjects_subjectid",
                        column: x => x.subjectid,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_headerTeacherid",
                table: "Courses",
                column: "headerTeacherid");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_subjectid",
                table: "Courses",
                column: "subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_studentid",
                table: "Enrollments",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_studyPlanid",
                table: "Enrollments",
                column: "studyPlanid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_CourseDtoid",
                table: "StudentEnrolledInCourses",
                column: "CourseDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_enrollmentid",
                table: "StudentEnrolledInCourses",
                column: "enrollmentid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolledInCourses_studentid",
                table: "StudentEnrolledInCourses",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolDtoid",
                table: "Students",
                column: "SchoolDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanDetails_studyPlanDtoid",
                table: "StudyPlanDetails",
                column: "studyPlanDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_SchoolDtoid",
                table: "StudyPlans",
                column: "SchoolDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudyPlanDetailDtoid",
                table: "Subjects",
                column: "StudyPlanDetailDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseDtoid",
                table: "Teachers",
                column: "CourseDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolDtoid",
                table: "Teachers",
                column: "SchoolDtoid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_headerTeacherid",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "StudentEnrolledInCourses");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "StudyPlanDetails");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
