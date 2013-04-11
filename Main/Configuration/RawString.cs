using System.Xml.Schema;
using System.Xml.Serialization;

namespace Configuration
{
	public class RawString : IXmlSerializable
	{
		public string Value { get; set; }

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(System.Xml.XmlReader reader)
		{
			Value = reader.ReadInnerXml();
		}

		public void WriteXml(System.Xml.XmlWriter writer)
		{
			writer.WriteRaw(Value);
		}
	}
}