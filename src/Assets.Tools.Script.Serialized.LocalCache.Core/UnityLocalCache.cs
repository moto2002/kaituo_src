using System;

namespace Assets.Tools.Script.Serialized.LocalCache.Core
{
	public abstract class UnityLocalCache<T> : IUnityLocalCache
	{
		public Func<string> suffixGetter;

		private readonly string _baseName;

		protected string Suffix
		{
			get
			{
				if (this.suffixGetter != null)
				{
					return this.suffixGetter();
				}
				return string.Empty;
			}
		}

		public string CacheName
		{
			get
			{
				if (!string.IsNullOrEmpty(this.Suffix))
				{
					return this._baseName + this.Suffix;
				}
				return this._baseName;
			}
		}

		public T Value
		{
			get
			{
				if (this.HasCache())
				{
					return this.GetLocalCache();
				}
				return default(T);
			}
			set
			{
				this.SaveLocalCache(value);
			}
		}

		protected UnityLocalCache(string name)
		{
			this._baseName = name;
		}

		public abstract bool HasCache();

		public abstract void DeleteCache();

		protected abstract T GetLocalCache();

		protected abstract void SaveLocalCache(T value);
	}
}
