using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcString : UnityLocalPlayerPrefsCache<string>
	{
		public LcString(string name) : base(name)
		{
		}

		protected override string GetLocalCache()
		{
			return PlayerPrefs.GetString(this.CacheName);
		}

		protected override void SaveLocalCache(string value)
		{
			PlayerPrefs.SetString(this.CacheName, value);
			PlayerPrefs.Save();
		}
	}
}
