using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DBConnection
{
    public class localDBConnection : IDBConnection
    {
        SqlConnection sqlConnection;
        string connectionString;

        public localDBConnection()
        {
            connectionString = String.Empty;
        }

        public localDBConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region IDBConnection

        public void Connect()
        {
            this.sqlConnection = new SqlConnection(this.connectionString);
            this.sqlConnection.Open();
        }

        public void Disconnect()
        {
            if (this.sqlConnection != null)
            {
                this.sqlConnection.Close();
            }
        }

        public bool ExecuteQuery(IQuery query)
        {
            try
            {
                string[] q = query.GetQueryData() as string[];
                SqlCommand sql_C = new SqlCommand(q[0], sqlConnection);
                sql_C.ExecuteNonQuery();
                sql_C = new SqlCommand(q[1], sqlConnection);
                sql_C.ExecuteNonQuery();
                return true;
            }
            catch//(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string GetLastResponse()
        {
            return "Something went wrong!";
        }
        #endregion

        #region IDisposable

        public void Dispose()
        { }

        #endregion
    }
}
