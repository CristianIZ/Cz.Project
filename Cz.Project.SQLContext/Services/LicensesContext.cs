using Cz.Project.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

        public License MapLicense(DataRow dataRow)
        {
            return new License()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                Name = dataRow["Name"].ToString()
            };
        }
    }
}
