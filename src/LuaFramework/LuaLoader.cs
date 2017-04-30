using Assets.LuaFramework.Extend;
using LuaInterface;
using System;
using System.IO;

namespace LuaFramework
{
	public class LuaLoader : LuaFileUtils
	{
		private static byte[] bytebuffer = new byte[524288];

		public LuaLoader()
		{
			LuaFileUtils.instance = this;
		}

		public override byte[] ReadFile(string fileName)
		{
			return File.ReadAllBytes(Assets.LuaFramework.Extend.Path.LuaPath(fileName));
		}

		public override void ReadFile(string fileName, out byte[] bytes, out int length)
		{
			FileStream fileStream = File.OpenRead(Assets.LuaFramework.Extend.Path.LuaPath(fileName));
			bytes = LuaLoader.bytebuffer;
			length = (int)fileStream.Length;
			fileStream.Read(bytes, 0, length);
			fileStream.Dispose();
		}
	}
}
