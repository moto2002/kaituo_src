using Assets.Tools.Script.Serialized.LocalCache.Core;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Serialized.LocalCache
{
	public class LcFloat : UnityLocalPlayerPrefsCache<float>
	{
		public LcFloat(string name) : base(name)
		{
		}

		protected override float GetLocalCache()
		{
			return PlayerPrefs.GetFloat(this.CacheName);
		}

		protected override void SaveLocalCache(float value)
		{
			PlayerPrefs.SetFloat(this.CacheName, value);
			PlayerPrefs.Save();
		}
	}
}
