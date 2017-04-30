using Assets.Tools.Script.File;
using System;

namespace Assets.Tools.Script.Serialized.LocalCache.Core
{
	public abstract class UnityLocalESFileCache<T> : UnityLocalCache<T>
	{
		private readonly string _fileSuffix;

		public string fileName
		{
			get
			{
				return this.CacheName + this._fileSuffix;
			}
		}

		protected UnityLocalESFileCache(string fileName, string fileSuffix = ".txt") : base(fileName)
		{
			this._fileSuffix = fileSuffix;
		}

		public override bool HasCache()
		{
			return ESFile.Exists(this.fileName);
		}

		public override void DeleteCache()
		{
			ESFile.Delete(this.fileName);
		}
	}
}
