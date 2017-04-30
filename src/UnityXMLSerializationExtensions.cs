using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public static class UnityXMLSerializationExtensions
{
	public static Encoding encoding = Encoding.UTF8;

	public static byte[] XMLSerialize_ToArray<T>(this T objToSerialize) where T : class
	{
		if (objToSerialize.IsTNull<T>())
		{
			return null;
		}
		XmlSerializer xmlSerializer = new XmlSerializer(objToSerialize.GetType());
		byte[] result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, UnityXMLSerializationExtensions.encoding))
			{
				xmlSerializer.Serialize(xmlTextWriter, objToSerialize);
				result = ((MemoryStream)xmlTextWriter.BaseStream).ToArray();
			}
		}
		return result;
	}

	public static string XMLSerialize_ToString<T>(this T objToSerialize) where T : class
	{
		if (objToSerialize.IsTNull<T>())
		{
			return null;
		}
		XmlSerializer xmlSerializer = new XmlSerializer(objToSerialize.GetType());
		string @string;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, UnityXMLSerializationExtensions.encoding))
			{
				xmlSerializer.Serialize(xmlTextWriter, objToSerialize);
				@string = UnityXMLSerializationExtensions.encoding.GetString(((MemoryStream)xmlTextWriter.BaseStream).ToArray());
			}
		}
		return @string;
	}

	public static T XMLDeserialize_ToObject<T>(this string strSerial) where T : class
	{
		if (string.IsNullOrEmpty(strSerial))
		{
			return (T)((object)null);
		}
		T result;
		using (MemoryStream memoryStream = new MemoryStream(UnityXMLSerializationExtensions.encoding.GetBytes(strSerial)))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			result = (T)((object)xmlSerializer.Deserialize(memoryStream));
		}
		return result;
	}

	public static T XMLDeserialize_ToObject<T>(byte[] objSerial) where T : class
	{
		if (objSerial.IsNullOrEmpty<byte>())
		{
			return (T)((object)null);
		}
		T result;
		using (MemoryStream memoryStream = new MemoryStream(objSerial))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			result = (T)((object)xmlSerializer.Deserialize(memoryStream));
		}
		return result;
	}

	public static void XMLSerialize_AndSaveToPersistentDataPath<T>(this T objToSerialize, string folderName, string filename) where T : class
	{
		if (objToSerialize.IsTNull<T>() || filename.IsNullOrEmpty())
		{
			return;
		}
		string text = (!folderName.IsNullOrEmpty()) ? Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename) : Path.Combine(Application.persistentDataPath, filename);
		text.CreateDirectoryIfNotExists();
		XmlSerializer xmlSerializer = new XmlSerializer(objToSerialize.GetType());
		using (TextWriter textWriter = new StreamWriter(text, false, UnityXMLSerializationExtensions.encoding))
		{
			xmlSerializer.Serialize(textWriter, objToSerialize);
		}
	}

	public static T XMLDeserialize_AndLoadFrom<T>(this string path) where T : class
	{
		if (path.IsNullOrEmpty())
		{
			return (T)((object)null);
		}
		if (!File.Exists(path))
		{
			return (T)((object)null);
		}
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		T result;
		using (TextReader textReader = new StreamReader(path, UnityXMLSerializationExtensions.encoding))
		{
			result = (xmlSerializer.Deserialize(textReader) as T);
		}
		return result;
	}

	public static T XMLDeserialize_AndLoadFromPersistentDataPath<T>(this string filename, string folderName) where T : class
	{
		if (filename.IsNullOrEmpty())
		{
			return (T)((object)null);
		}
		string path = (!folderName.IsNullOrEmpty()) ? Path.Combine(Path.Combine(Application.persistentDataPath, folderName), filename) : Path.Combine(Application.persistentDataPath, filename);
		return path.XMLDeserialize_AndLoadFrom<T>();
	}
}
