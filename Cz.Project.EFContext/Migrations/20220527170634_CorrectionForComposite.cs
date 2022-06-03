using Microsoft.EntityFrameworkCore.Migrations;

namespace Cz.Project.EFContext.Migrations
{
    public partial class CorrectionForComposite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Licenses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
