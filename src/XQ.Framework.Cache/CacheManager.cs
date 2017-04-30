using System;

namespace XQ.Framework.Cache
{
	public static class CacheManager
	{
		private static readonly CacheData<object> data = new CacheData<object>();

		public static bool HasData(string key)
		{
			return CacheManager.data.HasData(key);
		}

		public static void PutData<V>(string key, V v)
		{
			CacheManager.data.PutData(key, v);
		}

		public static void PutData(string key, Func<object> newCallBack, Action<object> addCallBack)
		{
			CacheManager.data.PutData(key, addCallBack, newCallBack);
		}

		public static V GetData<V>(string key)
		{
			return (V)((object)CacheManager.data.GetData(key));
		}
	}
}
