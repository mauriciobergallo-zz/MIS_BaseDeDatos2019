using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class FixRelationShipsInEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_studentid",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudyPlans_studyPlanid",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "studyPlanid",
                table: "Enrollments",
                newName: "studyPlanId");

            migrationBuilder.RenameColumn(
                name: "studentid",
                table: "Enrollments",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_studyPlanid",
                table: "Enrollments",
                newName: "IX_Enrollments_studyPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_studentid",
                table: "Enrollments",
                newName: "IX_Enrollments_studentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "studyPlanId",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "studentId",
                table: "Enrollments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_studentId",
                table: "Enrollments",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_StudyPlans_studyPlanId",
                table: "Enrollments",
                column: "studyPlanId",
                principalTable: "StudyPlans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_studentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_StudyPlans_studyPlanId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "studyPlanId",
                table: "Enrollments",
                newName: "studyPlanid");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Enrollments",
                newName: "studentid");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_studyPlanId",
                table: "Enrollments",
                newName: "IX_Enrollments_studyPlanid");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_studentId",
                table: "Enrollments",
                newName: "IX_Enrollments_studentid");

            migrationBuilder.AlterColumn<Guid>(
                name: "studyPlanid",
                table: "Enrollments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "studentid",
                table: "Enrollments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_studentid",
                table: "Enrollments",
                column: "studentid",
                principalTable: "Students",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_StudyPlans_studyPlanid",
                table: "Enrollments",
                column: "studyPlanid",
                principalTable: "StudyPlans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
