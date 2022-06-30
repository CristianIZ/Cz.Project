using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Cz.Project.SQLContext
{
    public static class SqlHelper
    {

        public static SqlParameter CreateParameter(string parameterName, object value)
        {
            var sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = $"@{parameterName}";
            sqlParameter.Value = value;

            return sqlParameter;
        }
    }
}
