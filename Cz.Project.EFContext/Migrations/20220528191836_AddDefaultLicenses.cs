using Microsoft.EntityFrameworkCore.Migrations;

namespace Cz.Project.EFContext.Migrations
{
    public partial class AddDefaultLicenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Licenses ON");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (1, 'All', 1)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (2, 'Restorant', 1)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (3, 'Edit menu', 1)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (4, 'Name', 0)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (5, 'Price', 0)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (6, 'Section', 0)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (7, 'Schedule', 1)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (8, 'Week days', 0)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (9, 'Open time', 0)");
            migrationBuilder.Sql("INSERT INTO Licenses ([Id], [Name], [HasChilds]) VALUES (10, 'Close time', 0)");
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
