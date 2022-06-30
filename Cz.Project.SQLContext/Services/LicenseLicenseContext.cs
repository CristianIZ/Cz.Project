using Cz.Project.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Cz.Project.SQLContext.Services
{
    public class LicenseLicenseContext
    {
        public IList<LicenseLicense> GetAll()
        {
            string query = $"SELECT * FROM [LicenseLicense]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadLicenses(table);
            }
        }

        public IList<LicenseLicense> ReadLicenses(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<LicenseLicense> licenses = new List<LicenseLicense>();

                foreach (DataRow item in table.Rows)
                {
                    licenses.Add(MapLicense(item));
                }

                return licenses;
            }
            else
            {
                return null;
            }
        }

        public LicenseLicense MapLicense(DataRow dataRow)
        {
            return new LicenseLicense()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                IdPadre = Convert.ToInt32(dataRow["IdPadre"]),
                IdHijo = Convert.ToInt32(dataRow["IdHijo"])
            };
        }

        public void Add(IList<LicenseLicense> licRel)
        {
            var commands = new List<SqlCommand>();
            var query = $"INSERT INTO LicenseLicense ([IdPadre], [IdHijo]) VALUES (@IdPadre, @IdHijo);";

            using (var DA = new SQLDataAccess())
            {
                foreach (var item in licRel)
                {
                    var sqlParameters = new ArrayList();
                    sqlParameters.Add(SqlHelper.CreateParameter("IdPadre", item.IdPadre));
                    sqlParameters.Add(SqlHelper.CreateParameter("IdHijo", item.IdHijo));

                    commands.Add(DA.CreateCommand(query, sqlParameters));
                }

                DA.InsertAllCommands(commands);
            }
        }
    }
}
