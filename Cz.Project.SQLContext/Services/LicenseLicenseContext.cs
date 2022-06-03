using Cz.Project.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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
                IdPadre = Convert.ToInt32(dataRow["IdPadre"]),
                IdHijo = Convert.ToInt32(dataRow["IdHijo"])
            };
        }
    }
}
