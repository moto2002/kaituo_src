using System;
using System.IO;
using System.Text;

namespace Assets.Tools.Script.File
{
	public static class FileTools
	{
		public static void VerifyDirection(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
			}
		}

		public static void Copy(string fromDir, string toDir, bool overwrite)
		{
			FileTools.VerifyDirection(toDir);
			File.Copy(fromDir, toDir, overwrite);
		}

		public static object Create(string dir)
		{
			FileTools.VerifyDirection(dir);
			return File.Create(dir);
		}

		public static void Delete(string dir)
		{
			File.Delete(dir);
		}

		public static bool Exists(string dir)
		{
			return File.Exists(dir);
		}

		public static void Move(string fromdir, string todir)
		{
			FileTools.VerifyDirection(todir);
			File.Move(fromdir, todir);
		}

		public static FileStream Open(string dir, FileMode mode)
		{
			return File.Open(dir, mode);
		}

		public static byte[] ReadAllBytes(string dir)
		{
			FileInfo fileInfo = new FileInfo(dir);
			long length = fileInfo.Length;
			FileStream fileStream = new FileStream(dir, FileMode.Open);
			byte[] array = new byte[length];
			fileStream.Read(array, 0, (int)length);
			fileStream.Close();
			return array;
		}

		public static string ReadAllText(string dir)
		{
			if (!FileTools.Exists(dir))
			{
				FileStream fileStream = FileTools.Create(dir) as FileStream;
				fileStream.Close();
			}
			return File.ReadAllText(dir);
		}

		public static void WriteAllText(string dir, string datas)
		{
			FileTools.VerifyDirection(dir);
			File.WriteAllText(dir, datas, Encoding.UTF8);
		}
	}
}
