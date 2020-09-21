using Microsoft.EntityFrameworkCore.Migrations;

namespace RH.Migrations
{
    public partial class CheckBoxAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckboxAwnser",
                table: "Technology",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckboxAwnser",
                table: "Technology");
        }
    }
}
