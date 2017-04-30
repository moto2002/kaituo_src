using LuaInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XQ.Framework.Lua;
using XQ.Framework.Lua.Utility;

namespace Assets.LuaFramework.Extend
{
	public class Path
	{
		private static readonly Dictionary<string, string> LuaPathDic = new Dictionary<string, string>(512);

		public static bool HasExtension(string path)
		{
			int length = path.Length;
			return length >= 4 && (path[length - 4] == '.' && path[length - 3] == 'l' && path[length - 2] == 'u') && path[length - 1] == 'a';
		}

		public static bool HasUserHead(string str)
		{
			return str.Length > 4 && (str[0] == 'U' && str[1] == 's' && str[2] == 'e' && str[3] == 'r') && str[4] == '/';
		}

		public static bool IsPathRooted(string path)
		{
			return System.IO.Path.IsPathRooted(path);
		}

		public static string GetExtension(string path)
		{
			return System.IO.Path.GetExtension(path);
		}

		public static string LuaPath(string name)
		{
			string str = UtilHelper.DataPath(true, true, false);
			string text;
			if (Path.LuaPathDic.TryGetValue(name, out text))
			{
				return text;
			}
			string key = name;
			if (Path.HasExtension(name))
			{
				name = name.Substring(0, name.Length - 4);
			}
			if (name.IndexOf('/') != -1)
			{
				if (Path.HasUserHead(name))
				{
					StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
					stringBuilder.Append("Lua/");
					stringBuilder.Append("User/");
					string[] array = name.Split(new char[]
					{
						'/'
					});
					int i = 1;
					int num = array.Length - 1;
					while (i < num)
					{
						stringBuilder.Append(array[i].CRCHash(true, 1012)).Append('/');
						i++;
					}
					stringBuilder.Append(array[array.Length - 1].CRCHash(true, 1012));
					stringBuilder.Append(".lua");
					text = str + StringBuilderCache.GetStringAndRelease(stringBuilder);
				}
				else
				{
					text = str + "Lua/" + name + ".lua";
				}
				Path.LuaPathDic.Add(key, text);
				return text;
			}
			text = str + "Lua/" + (GameManager.GetLuaScript(name, false) ?? name) + ".lua";
			Path.LuaPathDic.Add(key, text);
			return text;
		}
	}
}
