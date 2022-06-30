using Microsoft.EntityFrameworkCore.Migrations;

namespace Cz.Project.EFContext.Migrations
{
    public partial class DropLicenseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseLicense");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseLicense",
                columns: table => new
                {
                    IdPadre = table.Column<int>(type: "int", nullable: false),
                    IdHijo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
