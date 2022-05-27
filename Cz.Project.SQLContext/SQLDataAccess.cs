using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Cz.Project.SQLContext
{
    public class SQLDataAccess : IDisposable
    {
        string CadenaCnn = @"Data Source=DESKTOP-020RVT4;Initial Catalog=Cz.Project;Integrated Security=True";

        public SqlConnection Cnn { get; set; }

        public SQLDataAccess()
        {
            Cnn = new SqlConnection(CadenaCnn);
        }

        private void OpenConnection()
        {
            if (Cnn.State != ConnectionState.Open)
                Cnn.Open();
        }

        private void CloseConnection()
        {
            Cnn.Close();
            Cnn.Dispose();
        }

        public void Dispose()
        {
            Cnn.Close();
            Cnn.Dispose();
        }

        public DataTable Read(string query, ArrayList parameters = null)
        {
            var Dt = new DataTable();
            var Da = default(SqlDataAdapter);
            var Cmd = new SqlCommand();

            try
            {
                Da = new SqlDataAdapter(query, Cnn);

                if ((parameters != null))
                {
                    foreach (SqlParameter data in parameters)
                    {
                        Da.SelectCommand.Parameters.Add(data);
                    }
                }

                Da.Fill(Dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
            return Dt;
        }

        public int? ExecuteQuery(string query, ArrayList parameters)
        {
            try
            {
                int? result;

                using (var cmd = new SqlCommand(query, Cnn))
                {
                    try
                    {
                        OpenConnection();
                        cmd.Connection = Cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;

                        if ((parameters != null))
                        {
                            foreach (SqlParameter data in parameters)
                            {
                                cmd.Parameters.Add(data);
                            }
                        }

                        cmd.Transaction = Cnn.BeginTransaction();
                        result = (int?)cmd.ExecuteScalar();
                        cmd.Transaction.Commit();
                        CloseConnection();
                    }
                    catch (Exception)
                    {
                        cmd.Transaction.Rollback();
                        CloseConnection();
                        throw;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
