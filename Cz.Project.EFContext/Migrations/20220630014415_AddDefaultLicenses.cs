using Microsoft.EntityFrameworkCore.Migrations;

namespace Cz.Project.EFContext.Migrations
{
    public partial class AddDefaultLicenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Licenses ON");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (1, 'All', 1)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (2, 'Restorant', 2)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (3, 'Edit menu', 3)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (4, 'Name', 4)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (5, 'Price', 5)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (6, 'Section', 6)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (7, 'Schedule', 7)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (8, 'Week days', 8)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (9, 'Open time', 9)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [Code]) VALUES (10, 'Close time', 10)");
            migrationBuilder.Sql("SET IDENTITY_INSERT Licenses OFF");

            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (1, 2)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (2, 3)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (2, 7)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 4)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 5)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (3, 6)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 8)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 9)");
            migrationBuilder.Sql("INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (7, 10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Licenses");
            migrationBuilder.Sql("TRUNCATE TABLE LicenseLicense");
        }
    }
}
