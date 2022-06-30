using Cz.Project.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Cz.Project.SQLContext.Services
{
    public class LicensesContext
    {
        public IList<License> GetAll()
        {
            string query = $"SELECT * FROM [Licenses]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadLicenses(table);
            }
        }

        public License GetByCode(int parentCode)
        {
            string query = $"SELECT * FROM [Licenses] WHERE Code = @Code";

            using (var DA = new SQLDataAccess())
            {
                var sqlParameters = new ArrayList();
                sqlParameters.Add(SqlHelper.CreateParameter("Code", parentCode));

                var table = DA.Read(query, sqlParameters);
                return ReadLicenses(table).First();
            }
        }

        public List<License> GetRootLicenses()
        {
            string query = "SELECT * FROM Licenses WHERE Licenses.Id NOT IN (SELECT LicenseLicense.IdHijo FROM LicenseLicense)";

            throw new NotImplementedException();
        }

        public IList<License> ReadLicenses(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<License> licenses = new List<License>();

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

        public void Add(IList<License> lic)
        {
            var commands = new List<SqlCommand>();
            string query = $"INSERT INTO Licenses ([Name], [Code]) VALUES (@Name, @Code);";

            using (var DA = new SQLDataAccess())
            {
                foreach (var item in lic)
                {
                    var sqlParameters = new ArrayList();
                    sqlParameters.Add(SqlHelper.CreateParameter("Name", item.Name));
                    sqlParameters.Add(SqlHelper.CreateParameter("Code", item.Code));

                    commands.Add(DA.CreateCommand(query, sqlParameters));
                }

                DA.InsertAllCommands(commands);
            }
        }

        public License MapLicense(DataRow dataRow)
        {
            return new License()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                Name = dataRow["Name"].ToString(),
                Code = Convert.ToInt32(dataRow["Code"])
            };
        }
    }
}
