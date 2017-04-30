using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Assets.Tools.Script.Core.File
{
	public class FileUtility
	{
		public static void CreateAndWriteFile(string path, string info)
		{
			File.WriteAllText(path, info, new UTF8Encoding(false));
		}

		public static string ReadFile(string path)
		{
			return File.ReadAllText(path, new UTF8Encoding(false));
		}

		public static string GetFullPath(string assetsPath)
		{
			if (assetsPath.StartsWith("Assets/"))
			{
				assetsPath = assetsPath.Substring(6, assetsPath.Length - 6);
			}
			else if (!assetsPath.StartsWith("/"))
			{
				assetsPath = string.Format("{0}/", assetsPath);
			}
			return string.Format("{0}{1}", Application.dataPath, assetsPath);
		}

		public static string GetAssetsPath(string fullPath)
		{
			int num = fullPath.IndexOf("Assets/", StringComparison.Ordinal);
			return fullPath.Substring(num, fullPath.Length - num);
		}

		public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
			}
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				string destFileName = Path.Combine(destDirName, fileInfo.Name);
				fileInfo.CopyTo(destFileName, true);
			}
			if (copySubDirs)
			{
				DirectoryInfo[] array2 = directories;
				for (int j = 0; j < array2.Length; j++)
				{
					DirectoryInfo directoryInfo2 = array2[j];
					string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
					FileUtility.DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs);
				}
			}
		}
	}
}
