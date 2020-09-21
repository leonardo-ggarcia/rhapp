using Microsoft.EntityFrameworkCore.Migrations;

namespace RH.Migrations
{
    public partial class OtherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_JobId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Candidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Candidate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_JobId",
                table: "Candidate",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Job_JobId",
                table: "Candidate",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
