using Assets.Tools.Script.Serialized.LocalCache.Core;
using LitJson;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcJsonObject<T> : UnityLocalPlayerPrefsCache<T> where T : class
	{
		public LcJsonObject(string name) : base(name)
		{
		}

		protected override T GetLocalCache()
		{
			string @string = PlayerPrefs.GetString(this.CacheName);
			T result;
			try
			{
				T t = JsonMapper.ToObject<T>(@string);
				result = t;
			}
			catch (Exception)
			{
				result = (T)((object)null);
			}
			return result;
		}

		protected override void SaveLocalCache(T value)
		{
			try
			{
				string value2 = JsonMapper.ToJson(value);
				PlayerPrefs.SetString(this.CacheName, value2);
				PlayerPrefs.Save();
			}
			catch (Exception ex)
			{
				DebugConsole.Log(new object[]
				{
					ex
				});
			}
		}
	}
}
