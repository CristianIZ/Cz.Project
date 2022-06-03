using Cz.Project.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Cz.Project.SQLContext
{
    public class AdminUsersContext
    {
        public IList<AdminUsers> GetAll()
        {
            string query = $"SELECT * FROM [AdminUsers]";

            using (var DA = new SQLDataAccess())
            {
                var table = DA.Read(query);
                return ReadUsers(table);
            }
        }

        public AdminUsers GetByName(AdminUsers adminUsers)
        {
            string query = $"SELECT * FROM [AdminUsers] WHERE [Name] = @Name";

            var sqlParameters = new ArrayList();
            sqlParameters.Add(CreateParameter($"@{nameof(adminUsers.Name)}", adminUsers.Name));

            using (var DA = new SQLDataAccess())
            {
                var tabla = DA.Read(query, sqlParameters);
                return ReadUsers(tabla).FirstOrDefault();
            }
        }

        public void Delete(AdminUsers adminUser)
        {
            string query = $"DELETE FROM AdminUsers WHERE Id = @Id";

            var sqlParameters = new ArrayList();
            sqlParameters.Add(CreateParameter($"@{nameof(adminUser.Id)}", adminUser.Id));

            using (var DA = new SQLDataAccess())
            {
                DA.ExecuteQuery(query, sqlParameters);
            }
        }

        /// <summary>
        /// Set Name and Password for the id of the given user
        /// </summary>
        /// <param name="userToChange"></param>
        public void Update(AdminUsers userToChange)
        {
            string query = $"UPDATE AdminUsers SET [Name] = @Name, [Password] = @Password WHERE [Id] = @Id;";

            var sqlParameters = new ArrayList();

            sqlParameters.Add(CreateParameter($"@{nameof(userToChange.Id)}", userToChange.Id));
            sqlParameters.Add(CreateParameter($"@{nameof(userToChange.Name)}", userToChange.Name));
            sqlParameters.Add(CreateParameter($"@{nameof(userToChange.Password)}", userToChange.Password));

            using (var DA = new SQLDataAccess())
            {
                DA.ExecuteQuery(query, sqlParameters);
            }
        }

        public IList<AdminUsers> ReadUsers(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                IList<AdminUsers> users = new List<AdminUsers>();

                foreach (DataRow item in table.Rows)
                {
                    users.Add(MapUser(item));
                }

                return users;
            }
            else
            {
                return null;
            }
        }

        public AdminUsers MapUser(DataRow dataRow)
        {
            return new AdminUsers()
            {
                Id = Convert.ToInt32(dataRow["Id"]),
                Name = dataRow["Name"].ToString(),
                Password = dataRow["Password"].ToString()
            };
        }

        public SqlParameter CreateParameter(string parameterName, object value)
        {
            var sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = parameterName;
            sqlParameter.Value = value;

            return sqlParameter;
        }
    }
}
