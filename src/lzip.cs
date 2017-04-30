using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public class lzip
{
	private const string libname = "zipw";

	public static List<string> ninfo = new List<string>();

	public static List<long> uinfo = new List<long>();

	public static List<long> cinfo = new List<long>();

	public static int zipFiles;

	public static int zipFolders;

	public static int cProgress = 0;

	[DllImport("zipw")]
	internal static extern int zipGetTotalFiles(string zipArchive, IntPtr FileBuffer, int fileBufferLength);

	[DllImport("zipw")]
	internal static extern int zipGetInfo(string zipArchive, string path, IntPtr FileBuffer, int fileBufferLength);

	[DllImport("zipw")]
	internal static extern void releaseBuffer(IntPtr buffer);

	[DllImport("zipw")]
	internal static extern int zipGetEntrySize(string zipArchive, string entry, IntPtr FileBuffer, int fileBufferLength);

	[DllImport("zipw")]
	internal static extern int zipCD(int levelOfCompression, string zipArchive, string inFilePath, string fileName, string comment);

	[DllImport("zipw")]
	internal static extern bool zipBuf2File(int levelOfCompression, string zipArchive, string arc_filename, IntPtr buffer, int bufferSize);

	[DllImport("zipw")]
	internal static extern bool zipEntry2Buffer(string zipArchive, string entry, IntPtr buffer, int bufferSize, IntPtr FileBuffer, int fileBufferLength);

	[DllImport("zipw")]
	internal static extern IntPtr zipCompressBuffer(IntPtr source, int sourceLen, int levelOfCompression, ref int v);

	[DllImport("zipw")]
	internal static extern IntPtr zipDecompressBuffer(IntPtr source, int sourceLen, ref int v);

	[DllImport("zipw")]
	internal static extern int zipEX(string zipArchive, string outPath, IntPtr progress, IntPtr FileBuffer, int fileBufferLength);

	[DllImport("zipw")]
	internal static extern int zipEntry(string zipArchive, string arc_filename, string outpath, IntPtr FileBuffer, int fileBufferLength);

	public static int getTotalFiles(string zipArchive, byte[] FileBuffer = null)
	{
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			int result = lzip.zipGetTotalFiles(null, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
			return result;
		}
		return lzip.zipGetTotalFiles(zipArchive, IntPtr.Zero, 0);
	}

	public static long getFileInfo(string zipArchive, string path, byte[] FileBuffer = null)
	{
		lzip.ninfo.Clear();
		lzip.uinfo.Clear();
		lzip.cinfo.Clear();
		lzip.zipFiles = 0;
		lzip.zipFolders = 0;
		int num;
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			num = lzip.zipGetInfo(null, path, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
		}
		else
		{
			num = lzip.zipGetInfo(zipArchive, path, IntPtr.Zero, 0);
		}
		if (num == -1)
		{
			return -1L;
		}
		if (num == -2)
		{
			return -2L;
		}
		if (num == -3)
		{
			return -3L;
		}
		string path2 = path + "/uziplog.txt";
		if (!File.Exists(path2))
		{
			return -4L;
		}
		StreamReader streamReader = new StreamReader(path2);
		long num2 = 0L;
		long num3 = 0L;
		string text;
		while ((text = streamReader.ReadLine()) != null)
		{
			string[] array = text.Split(new char[]
			{
				'|'
			});
			lzip.ninfo.Add(array[0]);
			long.TryParse(array[1], out num2);
			num3 += num2;
			lzip.uinfo.Add(num2);
			if (num2 > 0L)
			{
				lzip.zipFiles++;
			}
			else
			{
				lzip.zipFolders++;
			}
			long.TryParse(array[2], out num2);
			lzip.cinfo.Add(num2);
		}
		streamReader.Close();
		streamReader.Dispose();
		File.Delete(path2);
		return num3;
	}

	public static int getEntrySize(string zipArchive, string entry, byte[] FileBuffer = null)
	{
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			int result = lzip.zipGetEntrySize(null, entry, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
			return result;
		}
		return lzip.zipGetEntrySize(zipArchive, entry, IntPtr.Zero, 0);
	}

	public static bool compressBuffer(byte[] source, ref byte[] outBuffer, int levelOfCompression)
	{
		if (levelOfCompression < 0)
		{
			levelOfCompression = 0;
		}
		if (levelOfCompression > 10)
		{
			levelOfCompression = 10;
		}
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipCompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, levelOfCompression, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return false;
		}
		Array.Resize<byte>(ref outBuffer, num);
		Marshal.Copy(intPtr, outBuffer, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return true;
	}

	public static int compressBufferFixed(byte[] source, ref byte[] outBuffer, int levelOfCompression, bool safe = true)
	{
		if (levelOfCompression < 0)
		{
			levelOfCompression = 0;
		}
		if (levelOfCompression > 10)
		{
			levelOfCompression = 10;
		}
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipCompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, levelOfCompression, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return 0;
		}
		if (num > outBuffer.Length)
		{
			if (safe)
			{
				gCHandle.Free();
				lzip.releaseBuffer(intPtr);
				return 0;
			}
			num = outBuffer.Length;
		}
		Marshal.Copy(intPtr, outBuffer, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return num;
	}

	public static byte[] compressBuffer(byte[] source, int levelOfCompression)
	{
		if (levelOfCompression < 0)
		{
			levelOfCompression = 0;
		}
		if (levelOfCompression > 10)
		{
			levelOfCompression = 10;
		}
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipCompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, levelOfCompression, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return null;
		}
		byte[] array = new byte[num];
		Marshal.Copy(intPtr, array, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return array;
	}

	public static bool decompressBuffer(byte[] source, ref byte[] outBuffer)
	{
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipDecompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return false;
		}
		Array.Resize<byte>(ref outBuffer, num);
		Marshal.Copy(intPtr, outBuffer, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return true;
	}

	public static int decompressBufferFixed(byte[] source, ref byte[] outBuffer, bool safe = true)
	{
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipDecompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return 0;
		}
		if (num > outBuffer.Length)
		{
			if (safe)
			{
				gCHandle.Free();
				lzip.releaseBuffer(intPtr);
				return 0;
			}
			num = outBuffer.Length;
		}
		Marshal.Copy(intPtr, outBuffer, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return num;
	}

	public static byte[] decompressBuffer(byte[] source)
	{
		GCHandle gCHandle = GCHandle.Alloc(source, GCHandleType.Pinned);
		int num = 0;
		IntPtr intPtr = lzip.zipDecompressBuffer(gCHandle.AddrOfPinnedObject(), source.Length, ref num);
		if (num == 0 || intPtr == IntPtr.Zero)
		{
			gCHandle.Free();
			lzip.releaseBuffer(intPtr);
			return null;
		}
		byte[] array = new byte[num];
		Marshal.Copy(intPtr, array, 0, num);
		gCHandle.Free();
		lzip.releaseBuffer(intPtr);
		return array;
	}

	public static bool entry2Buffer(string zipArchive, string entry, ref byte[] buffer, byte[] FileBuffer = null)
	{
		int num;
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			num = lzip.zipGetEntrySize(null, entry, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
		}
		else
		{
			num = lzip.zipGetEntrySize(zipArchive, entry, IntPtr.Zero, 0);
		}
		if (num <= 0)
		{
			return false;
		}
		Array.Resize<byte>(ref buffer, num);
		GCHandle gCHandle2 = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		bool result;
		if (FileBuffer != null)
		{
			GCHandle gCHandle3 = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			result = lzip.zipEntry2Buffer(null, entry, gCHandle2.AddrOfPinnedObject(), num, gCHandle3.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle3.Free();
		}
		else
		{
			result = lzip.zipEntry2Buffer(zipArchive, entry, gCHandle2.AddrOfPinnedObject(), num, IntPtr.Zero, 0);
		}
		gCHandle2.Free();
		return result;
	}

	public static byte[] entry2Buffer(string zipArchive, string entry, byte[] FileBuffer = null)
	{
		int num;
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			num = lzip.zipGetEntrySize(null, entry, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
		}
		else
		{
			num = lzip.zipGetEntrySize(zipArchive, entry, IntPtr.Zero, 0);
		}
		if (num <= 0)
		{
			return null;
		}
		byte[] array = new byte[num];
		GCHandle gCHandle2 = GCHandle.Alloc(array, GCHandleType.Pinned);
		bool flag;
		if (FileBuffer != null)
		{
			GCHandle gCHandle3 = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			flag = lzip.zipEntry2Buffer(null, entry, gCHandle2.AddrOfPinnedObject(), num, gCHandle3.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle3.Free();
		}
		else
		{
			flag = lzip.zipEntry2Buffer(zipArchive, entry, gCHandle2.AddrOfPinnedObject(), num, IntPtr.Zero, 0);
		}
		gCHandle2.Free();
		if (!flag)
		{
			return null;
		}
		return array;
	}

	public static bool buffer2File(int levelOfCompression, string zipArchive, string arc_filename, byte[] buffer, bool append = false)
	{
		if (!append && File.Exists(zipArchive))
		{
			File.Delete(zipArchive);
		}
		GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		if (levelOfCompression < 0)
		{
			levelOfCompression = 0;
		}
		if (levelOfCompression > 10)
		{
			levelOfCompression = 10;
		}
		bool result = lzip.zipBuf2File(levelOfCompression, zipArchive, arc_filename, gCHandle.AddrOfPinnedObject(), buffer.Length);
		gCHandle.Free();
		return result;
	}

	public static int extract_entry(string zipArchive, string arc_filename, string outpath, byte[] FileBuffer = null)
	{
		if (FileBuffer != null)
		{
			GCHandle gCHandle = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			int result = lzip.zipEntry(null, arc_filename, outpath, gCHandle.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle.Free();
			return result;
		}
		return lzip.zipEntry(zipArchive, arc_filename, outpath, IntPtr.Zero, 0);
	}

	public static int decompress_File(string zipArchive, string outPath, int[] progress, byte[] FileBuffer = null)
	{
		if (outPath.Substring(outPath.Length - 1, 1) != "/")
		{
			outPath += "/";
		}
		GCHandle gCHandle = GCHandle.Alloc(progress, GCHandleType.Pinned);
		int result;
		if (FileBuffer != null)
		{
			GCHandle gCHandle2 = GCHandle.Alloc(FileBuffer, GCHandleType.Pinned);
			result = lzip.zipEX(null, outPath, gCHandle.AddrOfPinnedObject(), gCHandle2.AddrOfPinnedObject(), FileBuffer.Length);
			gCHandle2.Free();
			gCHandle.Free();
			return result;
		}
		result = lzip.zipEX(zipArchive, outPath, gCHandle.AddrOfPinnedObject(), IntPtr.Zero, 0);
		gCHandle.Free();
		return result;
	}

	public static int compress_File(int levelOfCompression, string zipArchive, string inFilePath, bool append = false, string fileName = "", string comment = "")
	{
		if (!append && File.Exists(zipArchive))
		{
			File.Delete(zipArchive);
		}
		if (!File.Exists(inFilePath))
		{
			return -10;
		}
		if (fileName == string.Empty)
		{
			fileName = Path.GetFileName(inFilePath);
		}
		if (levelOfCompression < 0)
		{
			levelOfCompression = 0;
		}
		if (levelOfCompression > 10)
		{
			levelOfCompression = 10;
		}
		return lzip.zipCD(levelOfCompression, zipArchive, inFilePath, fileName, comment);
	}

	public static void compressDir(string sourceDir, int levelOfCompression, string zipArchive, Action<int, int, string> progress = null, bool includeRoot = false)
	{
		string text = sourceDir.Replace("\\", "/");
		if (Directory.Exists(text))
		{
			if (File.Exists(zipArchive))
			{
				File.Delete(zipArchive);
			}
			string[] array = text.Split(new char[]
			{
				'/'
			});
			string text2 = array[array.Length - 1];
			string str = text2;
			lzip.cProgress = 0;
			if (levelOfCompression < 0)
			{
				levelOfCompression = 0;
			}
			if (levelOfCompression > 10)
			{
				levelOfCompression = 10;
			}
			string[] files = Directory.GetFiles(text, "*", SearchOption.AllDirectories);
			int arg = files.Length;
			string[] array2 = files;
			for (int i = 0; i < array2.Length; i++)
			{
				string text3 = array2[i];
				string text4 = text3.Replace(text, text2).Replace("\\", "/");
				if (!includeRoot)
				{
					text4 = text4.Replace(str + "/", string.Empty);
				}
				lzip.compress_File(levelOfCompression, zipArchive, text3, true, text4, string.Empty);
				lzip.cProgress++;
				if (progress != null)
				{
					progress(arg, lzip.cProgress, text3);
				}
			}
		}
	}

	public static int getAllFiles(string Dir)
	{
		string[] files = Directory.GetFiles(Dir, "*", SearchOption.AllDirectories);
		return files.Length;
	}
}
