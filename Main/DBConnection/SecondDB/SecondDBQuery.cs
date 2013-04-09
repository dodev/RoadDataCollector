using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnection
{
	public class SecondDBQuery : IQuery
	{

		IEnumerable<string> values;

		public SecondDBQuery (IEnumerable<string> values)
		{
			this.values = values;
		}

		#region IQuery implementation

		public object GetQueryData ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append ("[");
			foreach (string val in values)
				sb.Append (val + ",");
			sb.Remove (sb.Length - 1,1);

			sb.Append ("]");

			return sb.ToString ();
		}

		#endregion
	}
}

