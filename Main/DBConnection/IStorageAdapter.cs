using System;

namespace DBConnection
{
	/// <summary>
	/// Переводит инфоримацию устройств на языке СУДБ
	/// </summary>
	public interface IStorageAdapter
	{
		IQuery PrepareQuery (object data);
	}
}

