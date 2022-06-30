using Microsoft.EntityFrameworkCore.Migrations;

namespace Cz.Project.EFContext.Migrations
{
    public partial class ForLicensesRemoveHasChildAddCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasChilds",
                table: "Licenses");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Licenses");

            migrationBuilder.AddColumn<bool>(
                name: "HasChilds",
                table: "Licenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
