using Microsoft.EntityFrameworkCore.Migrations;

namespace RH.Migrations
{
    public partial class FieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Job",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Candidate",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Candidate",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
