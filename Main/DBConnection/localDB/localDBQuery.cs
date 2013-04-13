using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnection
{
    public class localDBQuery : IQuery
    {
        string table;
        int ID;
        string dataString;
        DateTime time;

        public localDBQuery(string table, int ID, string dataString, DateTime time)
        {
            this.table = table;
            this.ID = ID;
            this.dataString = dataString;
            this.time = time;
        }

        #region IQuery

        public object GetQueryData()
        {
            StringBuilder mainTQuery = new StringBuilder();
            StringBuilder tableQuery = new StringBuilder();

            mainTQuery.AppendFormat("Insert [MainTable] (ID) Values ({0})", this.ID);
            tableQuery.AppendFormat("Insert [{0}] (ID, dataString, Date) Values ({1}, '{2}', '{3}')", this.table, this.ID, this.dataString, this.time.ToString("yyyy-MM-dd hh:mm:ss"));

            IEnumerable<string> rValue = new string[] { mainTQuery.ToString(), tableQuery.ToString() };
            return rValue;
        }

        #endregion
    }
}
