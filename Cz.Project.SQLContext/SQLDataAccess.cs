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

        public void ExecuteQuery(string query, ArrayList parameters)
        {
            try
            {
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

                        var result = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        CloseConnection();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlCommand CreateCommand(string query, ArrayList parameters)
        {
            try
            {
                var command = new SqlCommand(query);

                if ((parameters != null))
                {
                    foreach (SqlParameter data in parameters)
                    {
                        command.Parameters.Add(data);
                    }
                }

                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertAllCommands(IList<SqlCommand> sqlCommands)
        {
            SqlTransaction transaction = null;

            try
            {
                OpenConnection();
                transaction = Cnn.BeginTransaction();

                foreach (var cmd in sqlCommands)
                {
                    cmd.Connection = Cnn;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
