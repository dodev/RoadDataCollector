using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Configuration
{
	public class XmlConfigurator : IConfigurator
	{
		public XmlConfigurator(string filePath)
		{
			_filePath = filePath;
		}

		public void Dispose()
		{ }

		public void Load()
		{
			_values.Clear();
			var document = XDocument.Load(_filePath);
			foreach (var element in document.Root.Elements())
			{
				ParseValue(element);
			}
		}

		public void Save()
		{
			var document = new XDocument();
			var root = new XElement("Configuration");
			document.Add(root);

			foreach (var configuration in _values)
			{
				var serializedValue = SerializeValue(configuration.Value);
				var serializedValueElement = XElement.Parse(serializedValue);
				root.Add(new XElement(configuration.Key,
					new XAttribute(TypeAttribute, configuration.Value.GetType().ToString()),
					serializedValueElement));
			}

			document.Save(_filePath, SaveOptions.OmitDuplicateNamespaces);
		}

		/// <summary>
		/// Возвращает null, если значение не найдено.
		/// </summary>
		public object GetItem(string name)
		{
			object value;
			_values.TryGetValue(name, out value);
			return value;
		}

		public void SetItem(string name, object value)
		{
			_values[name] = value;
		}

		private void ParseValue(XElement element)
		{
			var configurationName = element.Name.LocalName;
			var configurationType = element.Attribute(TypeAttribute).Value;
			var type = Type.GetType(configurationType);
			var serializer = new XmlSerializer(type);
			var serializedElement = element.Elements().Single();
			var value = serializer.Deserialize(serializedElement.CreateReader());
			_values[configurationName] = value;
		}

		private string SerializeValue(object value)
		{
			var serializer = new XmlSerializer(value.GetType());

			using (var ms = new MemoryStream())
			{
				// Для пропуска декларации XML.
				var xmlSettings = 
					new XmlWriterSettings
					{
						OmitXmlDeclaration = true,
						Indent = true
					};

				XmlWriter xmlWriter = XmlWriter.Create(ms, xmlSettings);
				serializer.Serialize(xmlWriter, value);

				ms.Position = 0;
				using (var streamReader = new StreamReader(ms))
				{
					var serializedValue = streamReader.ReadToEnd();
					return serializedValue;
				}
			}
		}

		const string TypeAttribute = "Type";
		readonly Dictionary<string, object> _values = new Dictionary<string,object>();
		readonly string _filePath;
	}
}