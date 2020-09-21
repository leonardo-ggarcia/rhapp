using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RH.Migrations
{
    public partial class NewTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cand_Job");

            migrationBuilder.DropTable(
                name: "Cand_Tech");

            migrationBuilder.DropTable(
                name: "Tech_Job");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cand_Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CandidateId = table.Column<int>(nullable: true),
                    JobId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cand_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cand_Job_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cand_Job_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cand_Tech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CandidateId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cand_Tech", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cand_Tech_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cand_Tech_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tech_Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobId = table.Column<int>(nullable: true),
                    TechnologyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tech_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tech_Job_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tech_Job_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cand_Job_CandidateId",
                table: "Cand_Job",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cand_Job_JobId",
                table: "Cand_Job",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Cand_Tech_CandidateId",
                table: "Cand_Tech",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cand_Tech_TechnologyId",
                table: "Cand_Tech",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Job_JobId",
                table: "Tech_Job",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Tech_Job_TechnologyId",
                table: "Tech_Job",
                column: "TechnologyId");
        }
    }
}
