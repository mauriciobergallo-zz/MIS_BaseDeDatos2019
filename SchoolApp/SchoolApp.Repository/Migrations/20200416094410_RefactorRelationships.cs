using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Repository.Migrations
{
    public partial class RefactorRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolDtoid",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlanDetails_StudyPlans_studyPlanDtoid",
                table: "StudyPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlans_Schools_SchoolDtoid",
                table: "StudyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_StudyPlanDetails_StudyPlanDetailDtoid",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Schools_SchoolDtoid",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SchoolDtoid",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StudyPlanDetailDtoid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_StudyPlans_SchoolDtoid",
                table: "StudyPlans");

            migrationBuilder.DropIndex(
                name: "IX_StudyPlanDetails_studyPlanDtoid",
                table: "StudyPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolDtoid",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolDtoid",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudyPlanDetailDtoid",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SchoolDtoid",
                table: "StudyPlans");

            migrationBuilder.DropColumn(
                name: "studyPlanDtoid",
                table: "StudyPlanDetails");

            migrationBuilder.DropColumn(
                name: "SchoolDtoid",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "schoolId",
                table: "Teachers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "StudyPlans",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "schoolId",
                table: "StudyPlans",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "studyPlanId",
                table: "StudyPlanDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "subjectId",
                table: "StudyPlanDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "schoolId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Schools",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanDetails_studyPlanId",
                table: "StudyPlanDetails",
                column: "studyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanDetails_subjectId",
                table: "StudyPlanDetails",
                column: "subjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlanDetails_StudyPlans_studyPlanId",
                table: "StudyPlanDetails",
                column: "studyPlanId",
                principalTable: "StudyPlans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlanDetails_Subjects_subjectId",
                table: "StudyPlanDetails",
                column: "subjectId",
                principalTable: "Subjects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlanDetails_StudyPlans_studyPlanId",
                table: "StudyPlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlanDetails_Subjects_subjectId",
                table: "StudyPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudyPlanDetails_studyPlanId",
                table: "StudyPlanDetails");

            migrationBuilder.DropIndex(
                name: "IX_StudyPlanDetails_subjectId",
                table: "StudyPlanDetails");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "name",
                table: "StudyPlans");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "StudyPlans");

            migrationBuilder.DropColumn(
                name: "studyPlanId",
                table: "StudyPlanDetails");

            migrationBuilder.DropColumn(
                name: "subjectId",
                table: "StudyPlanDetails");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Schools");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolDtoid",
                table: "Teachers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudyPlanDetailDtoid",
                table: "Subjects",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolDtoid",
                table: "StudyPlans",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "studyPlanDtoid",
                table: "StudyPlanDetails",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolDtoid",
                table: "Students",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolDtoid",
                table: "Teachers",
                column: "SchoolDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StudyPlanDetailDtoid",
                table: "Subjects",
                column: "StudyPlanDetailDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_SchoolDtoid",
                table: "StudyPlans",
                column: "SchoolDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanDetails_studyPlanDtoid",
                table: "StudyPlanDetails",
                column: "studyPlanDtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolDtoid",
                table: "Students",
                column: "SchoolDtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolDtoid",
                table: "Students",
                column: "SchoolDtoid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlanDetails_StudyPlans_studyPlanDtoid",
                table: "StudyPlanDetails",
                column: "studyPlanDtoid",
                principalTable: "StudyPlans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlans_Schools_SchoolDtoid",
                table: "StudyPlans",
                column: "SchoolDtoid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_StudyPlanDetails_StudyPlanDetailDtoid",
                table: "Subjects",
                column: "StudyPlanDetailDtoid",
                principalTable: "StudyPlanDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Schools_SchoolDtoid",
                table: "Teachers",
                column: "SchoolDtoid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
