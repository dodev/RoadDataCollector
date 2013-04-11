using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Configuration
{
	/// <summary>
	/// Для сериализации словарей.
	/// <seealso cref="http://stackoverflow.com/questions/1124597/why-isnt-there-an-xml-serializable-dictionary-in-net/5941122#5941122"/>
	/// </summary>
	public static class SerializationExtensions
	{
		public static RawString Serialize<T>(this T obj)
		{
			var serializer = new DataContractSerializer(obj.GetType());
			using (var memoryStream = new MemoryStream())
			{
				serializer.WriteObject(memoryStream, obj);
				memoryStream.Position = 0;
				using (var reader = new StreamReader(memoryStream))
				{
					var s = reader.ReadToEnd();
					return new RawString { Value = s };
				}
			}
		}

		public static T Deserialize<T>(this RawString serialized)
		{
			var serializer = new DataContractSerializer(typeof(T));
			using (var reader = new StringReader(serialized.Value))
			using (var stm = new XmlTextReader(reader))
			{
				return (T)serializer.ReadObject(stm);
			}
		}
	}
}