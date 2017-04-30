using Assets.Tools.Script.File;
using LuaInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class PlayerPrefsCache
	{
		private struct DirtyData
		{
			public string Key;

			public string Value;

			public static void AddSetString(string key, string value, List<PlayerPrefsCache.DirtyData> dirtyData)
			{
				dirtyData.Add(new PlayerPrefsCache.DirtyData
				{
					Key = key,
					Value = value
				});
			}

			public static void AddDeleteKey(string key, List<PlayerPrefsCache.DirtyData> dirtyData)
			{
				dirtyData.Add(new PlayerPrefsCache.DirtyData
				{
					Key = key,
					Value = "⌈d⌋" + key
				});
			}
		}

		private const string FragmentLengthTag = "⌈f⌋";

		private const string DeleteTag = "⌈d⌋";

		private const string SplitTag = "⌈s⌋";

		public int MaxFragmentLength;

		private bool holdStreamWriter;

		private Dictionary<string, string> datas;

		private string path;

		private List<PlayerPrefsCache.DirtyData> dirtyDatas = new List<PlayerPrefsCache.DirtyData>();

		public PlayerPrefsCache(string name)
		{
			this.holdStreamWriter = false;
			this.path = name + ".txt";
			this.MaxFragmentLength = 0;
		}

		public PlayerPrefsCache(string name, int maxFragmentLength, bool holdStreamWriter)
		{
			this.holdStreamWriter = holdStreamWriter;
			this.path = name + ".txt";
			this.MaxFragmentLength = maxFragmentLength;
		}

		~PlayerPrefsCache()
		{
			this.ReleaseStreamWriter();
		}

		public void SetString(string key, string value)
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			this.datas[key] = value;
			PlayerPrefsCache.DirtyData.AddSetString(key, value, this.dirtyDatas);
		}

		public string GetString(string key)
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			string result;
			this.datas.TryGetValue(key, out result);
			return result;
		}

		public void DeleteKey(string key)
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			this.datas.Remove(key);
			PlayerPrefsCache.DirtyData.AddDeleteKey(key, this.dirtyDatas);
		}

		public List<string> GetAllString()
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> current in this.datas)
			{
				if (!(current.Key == "⌈f⌋"))
				{
					list.Add(current.Value);
				}
			}
			return list;
		}

		public Dictionary<string, string> GetAllKV()
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> current in this.datas)
			{
				if (!(current.Key == "⌈f⌋"))
				{
					dictionary[current.Key] = current.Value;
				}
			}
			return dictionary;
		}

		public void GetAllKVToLuaTable(LuaTable table)
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			foreach (KeyValuePair<string, string> current in this.datas)
			{
				if (!(current.Key == "⌈f⌋"))
				{
					table[current.Key] = current.Value;
				}
			}
		}

		public void Clear()
		{
			if (this.datas == null)
			{
				this.datas = new Dictionary<string, string>();
			}
			else
			{
				this.datas.Clear();
			}
			this.DefragSave();
		}

		public void Save()
		{
			if (this.dirtyDatas.Count <= 0)
			{
				return;
			}
			if (this.datas == null)
			{
				this.Reload();
			}
			StringBuilder stringBuilder = new StringBuilder(this.datas.Count << 4);
			for (int i = 0; i < this.dirtyDatas.Count; i++)
			{
				PlayerPrefsCache.DirtyData dirtyData = this.dirtyDatas[i];
				stringBuilder.Append(dirtyData.Key);
				stringBuilder.Append("⌈s⌋");
				stringBuilder.Append(dirtyData.Value);
				stringBuilder.Append("⌈s⌋");
			}
			this.dirtyDatas.Clear();
			if (this.MaxFragmentLength > 0)
			{
				int num = stringBuilder.Length;
				string value;
				bool flag = this.datas.TryGetValue("⌈f⌋", out value);
				if (flag)
				{
					int num2 = Convert.ToInt32(value);
					num += num2;
				}
				this.datas["⌈f⌋"] = num.ToString();
				stringBuilder.Append("⌈f⌋");
				stringBuilder.Append("⌈s⌋");
				stringBuilder.Append(num.ToString());
				stringBuilder.Append("⌈s⌋");
			}
			ESFile.Save(stringBuilder.ToString(), this.path, FileMode.Append);
		}

		public void DefragSave()
		{
			if (this.datas == null)
			{
				this.Reload();
			}
			if (this.MaxFragmentLength > 0)
			{
				this.datas.Remove("⌈f⌋");
			}
			this.dirtyDatas.Clear();
			StringBuilder stringBuilder = new StringBuilder(this.datas.Count << 4);
			foreach (KeyValuePair<string, string> current in this.datas)
			{
				stringBuilder.Append(current.Key);
				stringBuilder.Append("⌈s⌋");
				stringBuilder.Append(current.Value);
				stringBuilder.Append("⌈s⌋");
			}
			this.ReleaseStreamWriter();
			ESFile.Save(stringBuilder.ToString(), this.path, FileMode.Create);
			this.HoldStreamWriter();
		}

		public void Reload()
		{
			try
			{
				this.ReleaseStreamWriter();
				string text = null;
				if (ESFile.Exists(this.path))
				{
					text = ESFile.LoadString(this.path);
				}
				this.dirtyDatas.Clear();
				this.datas = new Dictionary<string, string>();
				if (text.IsNOTNullOrEmpty())
				{
					string[] array = text.Split(new string[]
					{
						"⌈s⌋"
					}, StringSplitOptions.None);
					for (int i = 0; i < array.Length - 1; i += 2)
					{
						string text2 = array[i];
						string text3 = array[i + 1];
						if (text3.StartsWith("⌈d⌋") && text3 == "⌈d⌋" + text2)
						{
							this.datas.Remove(text2);
						}
						else
						{
							this.datas[text2] = text3;
						}
					}
					if (this.MaxFragmentLength > 0)
					{
						string value;
						bool flag = this.datas.TryGetValue("⌈f⌋", out value);
						if (flag)
						{
							int num = Convert.ToInt32(value);
							if (num > this.MaxFragmentLength)
							{
								this.DefragSave();
							}
						}
					}
				}
				this.HoldStreamWriter();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
			}
		}

		private void HoldStreamWriter()
		{
			if (this.holdStreamWriter)
			{
				ESFile.HoldStreamWriter(this.path, FileMode.Append, null);
			}
		}

		private void ReleaseStreamWriter()
		{
			if (this.holdStreamWriter)
			{
				ESFile.ReleaseStreamWriter(this.path);
			}
		}
	}
}
