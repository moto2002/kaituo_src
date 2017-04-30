using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assets.Tools.Script.File
{
	public class ESFile
	{
		private static UTF8Encoding utf8Encoding = new UTF8Encoding(false);

		private static readonly Dictionary<string, StreamWriter> holdedStreamWriters = new Dictionary<string, StreamWriter>();

		public static string LoadString(string path)
		{
			path = ESFile.GetAbsolutePath(path);
			return ESFile.ReadStringFile(path);
		}

		public static void Save(string info, string path, FileMode mode = FileMode.Create)
		{
			path = ESFile.GetAbsolutePath(path);
			ESFile.CreateORwriteFile(path, info, mode);
		}

		public static void SaveAsCreate(string info, string path)
		{
			ESFile.Save(info, path, FileMode.Create);
		}

		public static void SaveAsAppend(string info, string path)
		{
			ESFile.Save(info, path, FileMode.Append);
		}

		public static void SaveRaw(byte[] bytes, string path)
		{
			path = ESFile.GetAbsolutePath(path);
			ESFile.CreateDirectoryIfNonexistence(path);
			File.WriteAllBytes(path, bytes);
		}

		public static byte[] LoadRaw(string path)
		{
			path = ESFile.GetAbsolutePath(path);
			return ESFile.ReadBytesFile(path);
		}

		public static void SaveXMLObject(string path, object objToSerialize)
		{
			path = ESFile.GetAbsolutePath(path);
			objToSerialize.XMLSerialize_AndSaveToPersistentDataPath(Path.GetDirectoryName(path), Path.GetFileName(path));
		}

		public static T LoadXMLObject<T>(string path) where T : class
		{
			path = ESFile.GetAbsolutePath(path);
			return Path.GetFileName(path).XMLDeserialize_AndLoadFromPersistentDataPath(Path.GetDirectoryName(path));
		}

		public static bool Exists(string path)
		{
			path = ESFile.GetAbsolutePath(path);
			if (path.EndsWith("/"))
			{
				return Directory.Exists(path);
			}
			return File.Exists(path);
		}

		public static void Delete(string path)
		{
			path = ESFile.GetAbsolutePath(path);
			if (path.EndsWith("/"))
			{
				if (Directory.Exists(path))
				{
					Directory.Delete(path, true);
				}
			}
			else if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		public static string[] GetFiles(string folderPath)
		{
			folderPath = ESFile.GetAbsolutePath(folderPath);
			string[] files = Directory.GetFiles(folderPath);
			string[] array = new string[files.Length];
			for (int i = 0; i < files.Length; i++)
			{
				string text = files[i].Substring(folderPath.Length, files[i].Length - folderPath.Length);
				array[i] = text;
			}
			return array;
		}

		private static string GetAbsolutePath(string path)
		{
			return Path.Combine(LoadPath.saveLoadPath, path);
		}

		private static void CreateDirectoryIfNonexistence(string path)
		{
			string directoryName = Path.GetDirectoryName(path);
			if (directoryName != null && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
		}

		public static void HoldStreamWriter(string path, FileMode mode = FileMode.Create, Encoding encoding = null)
		{
			path = ESFile.GetAbsolutePath(path);
			if (encoding == null)
			{
				encoding = ESFile.utf8Encoding;
			}
			bool flag;
			ESFile.holdedStreamWriters[path] = ESFile.CreateStreamWriter(path, mode, encoding, out flag);
		}

		public static void ReleaseStreamWriter(string path)
		{
			path = ESFile.GetAbsolutePath(path);
			StreamWriter streamWriter;
			bool flag = ESFile.holdedStreamWriters.TryGetValue(path, out streamWriter);
			if (flag)
			{
				streamWriter.Close();
				streamWriter.Dispose();
				ESFile.holdedStreamWriters.Remove(path);
			}
		}

		public static void CreateORwriteFile(string path, string info, FileMode mode = FileMode.Create)
		{
			try
			{
				bool flag;
				StreamWriter streamWriter = ESFile.CreateStreamWriter(path, mode, ESFile.utf8Encoding, out flag);
				streamWriter.Write(info);
				streamWriter.Flush();
				if (!flag)
				{
					streamWriter.Close();
					streamWriter.Dispose();
				}
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
			}
		}

		public static void CreateORwriteFile(string path, byte[] info, FileMode mode = FileMode.Create)
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(path, mode == FileMode.Append);
				streamWriter.Write(info);
				streamWriter.Close();
				streamWriter.Dispose();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
			}
		}

		private static StreamWriter CreateStreamWriter(string path, FileMode mode, Encoding encoding, out bool holded)
		{
			StreamWriter result;
			holded = ESFile.holdedStreamWriters.TryGetValue(path, out result);
			if (!holded)
			{
				path.CreateDirectoryIfNotExists();
				result = new StreamWriter(path, mode == FileMode.Append, encoding);
			}
			return result;
		}

		public static string ReadStringFile(string path)
		{
			StreamReader streamReader = new StreamReader(path, ESFile.utf8Encoding);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			streamReader.Dispose();
			return result;
		}

		public static byte[] ReadBytesFile(string path)
		{
			FileStream fileStream = new FileStream(path, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			fileStream.Dispose();
			return array;
		}
	}
}
