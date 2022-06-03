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

            migrationBuilder.Sql("UPDATE Licenses SET Code = 1 WHERE Licenses.Id = 1");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 2 WHERE Licenses.Id = 2");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 3 WHERE Licenses.Id = 3");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 4 WHERE Licenses.Id = 4");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 5 WHERE Licenses.Id = 5");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 6 WHERE Licenses.Id = 6");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 7 WHERE Licenses.Id = 7");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 8 WHERE Licenses.Id = 8");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 9 WHERE Licenses.Id = 9");
            migrationBuilder.Sql("UPDATE Licenses SET Code = 10 WHERE Licenses.Id = 10");
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
