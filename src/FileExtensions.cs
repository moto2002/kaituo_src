using System;
using System.IO;

public static class FileExtensions
{
	public static void CreateDirectoryIfNotExists(this string folder)
	{
		if (folder.IsNullOrEmpty())
		{
			return;
		}
		string directoryName = Path.GetDirectoryName(folder);
		if (directoryName.IsNullOrEmpty())
		{
			return;
		}
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
	}
}
