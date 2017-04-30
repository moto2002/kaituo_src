using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace LuaInterface
{
	public class LuaFileUtils
	{
		public bool beZip;

		protected List<string> searchPaths = new List<string>();

		protected Dictionary<string, AssetBundle> zipMap = new Dictionary<string, AssetBundle>();

		protected static LuaFileUtils instance;

		public static LuaFileUtils Instance
		{
			get
			{
				if (LuaFileUtils.instance == null)
				{
					LuaFileUtils.instance = new LuaFileUtils();
				}
				return LuaFileUtils.instance;
			}
			protected set
			{
				LuaFileUtils.instance = value;
			}
		}

		public LuaFileUtils()
		{
			LuaFileUtils.instance = this;
		}

		public virtual void Dispose()
		{
			if (LuaFileUtils.instance != null)
			{
				LuaFileUtils.instance = null;
				this.searchPaths.Clear();
				foreach (KeyValuePair<string, AssetBundle> current in this.zipMap)
				{
					current.Value.Unload(true);
				}
				this.zipMap.Clear();
			}
		}

		public bool AddSearchPath(string path, bool front = false)
		{
			int num = this.searchPaths.IndexOf(path);
			if (num >= 0)
			{
				return false;
			}
			if (front)
			{
				this.searchPaths.Insert(0, path);
			}
			else
			{
				this.searchPaths.Add(path);
			}
			return true;
		}

		public bool RemoveSearchPath(string path)
		{
			int num = this.searchPaths.IndexOf(path);
			if (num >= 0)
			{
				this.searchPaths.RemoveAt(num);
				return true;
			}
			return false;
		}

		public string GetPackagePath()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append(";");
			for (int i = 0; i < this.searchPaths.Count; i++)
			{
				stringBuilder.Append(this.searchPaths[i]);
				stringBuilder.Append(';');
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		public void AddSearchBundle(string name, AssetBundle bundle)
		{
			this.zipMap[name] = bundle;
		}

		public string FindFile(string fileName)
		{
			if (fileName == string.Empty)
			{
				return string.Empty;
			}
			if (Path.IsPathRooted(fileName))
			{
				if (!fileName.EndsWith(".lua"))
				{
					fileName += ".lua";
				}
				return fileName;
			}
			if (fileName.EndsWith(".lua"))
			{
				fileName = fileName.Substring(0, fileName.Length - 4);
			}
			for (int i = 0; i < this.searchPaths.Count; i++)
			{
				string text = this.searchPaths[i].Replace("?", fileName);
				if (File.Exists(text))
				{
					return text;
				}
			}
			return null;
		}

		public virtual void ReadFile(string fileName, out byte[] bytes, out int length)
		{
			bytes = this.ReadFile(fileName);
			length = bytes.Length;
		}

		public virtual byte[] ReadFile(string fileName)
		{
			if (!this.beZip)
			{
				string text = this.FindFile(fileName);
				byte[] result = null;
				if (!string.IsNullOrEmpty(text) && File.Exists(text))
				{
					result = File.ReadAllBytes(text);
				}
				return result;
			}
			return this.ReadZipFile(fileName);
		}

		public virtual string FindFileError(string fileName)
		{
			if (Path.IsPathRooted(fileName))
			{
				return fileName;
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			if (fileName.EndsWith(".lua"))
			{
				fileName = fileName.Substring(0, fileName.Length - 4);
			}
			for (int i = 0; i < this.searchPaths.Count; i++)
			{
				stringBuilder.AppendFormat("\n\tno file '{0}'", this.searchPaths[i]);
			}
			stringBuilder = stringBuilder.Replace("?", fileName);
			if (this.beZip)
			{
				int num = fileName.LastIndexOf('/');
				string text = string.Empty;
				if (num > 0)
				{
					text = fileName.Substring(0, num);
					text = text.Replace('/', '_');
					text = string.Format("lua_{0}.unity3d", text);
				}
				else
				{
					text = "lua.unity3d";
				}
				stringBuilder.AppendFormat("\n\tno file '{0}' in {1}", fileName, text);
			}
			return StringBuilderCache.GetStringAndRelease(stringBuilder);
		}

		private byte[] ReadZipFile(string fileName)
		{
			AssetBundle assetBundle = null;
			byte[] result = null;
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			stringBuilder.Append("lua");
			int num = fileName.LastIndexOf('/');
			if (num > 0)
			{
				stringBuilder.Append("_");
				stringBuilder.Append(fileName.Substring(0, num).ToLower());
				stringBuilder.Replace('/', '_');
				fileName = fileName.Substring(num + 1);
			}
			if (!fileName.EndsWith(".lua"))
			{
				fileName += ".lua";
			}
			fileName += ".bytes";
			string stringAndRelease = StringBuilderCache.GetStringAndRelease(stringBuilder);
			this.zipMap.TryGetValue(stringAndRelease, out assetBundle);
			if (assetBundle != null)
			{
				TextAsset textAsset = assetBundle.LoadAsset<TextAsset>(fileName);
				if (textAsset != null)
				{
					result = textAsset.bytes;
					Resources.UnloadAsset(textAsset);
				}
			}
			return result;
		}

		public static string GetOSDir()
		{
			return LuaConst.osDir;
		}
	}
}
