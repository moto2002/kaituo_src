using System;

namespace Assets.Tools.Script.Serialized.LocalCache.Core
{
	public interface IUnityLocalCache
	{
		string CacheName
		{
			get;
		}

		bool HasCache();

		void DeleteCache();
	}
}
