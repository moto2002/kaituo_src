using System;
using System.IO;
using XQ.Framework.Lua.Utility;

namespace Assets.Tools.Script.Net.Downloader
{
	public class ZipLoader : LocalVersionEnableLoader
	{
		public byte[] Bytes;

		public ZipLoader(string url, int version) : base(url, version)
		{
		}

		protected override string GetCacheName()
		{
			return "zip/" + base.GetCacheName() + ".zip";
		}

		protected override void OnLoadCompleteHandler()
		{
			if (base.www != null)
			{
				this.Bytes = base.www.bytes;
			}
			base.OnLoadCompleteHandler();
		}

		protected override void LoadFromLocal()
		{
			try
			{
				base.LoadComplete();
			}
			catch (Exception)
			{
				if (this.HasLocal())
				{
					File.Delete(Path.Combine(UtilHelper.DataPath(true, false, false), base.cacheName));
				}
				throw;
			}
		}

		public override bool HasLocal()
		{
			return File.Exists(Path.Combine(UtilHelper.DataPath(true, false, false), base.cacheName));
		}

		protected override void OnUnloadLocal()
		{
			base.OnUnloadLocal();
			if (this.HasLocal())
			{
				File.Delete(Path.Combine(UtilHelper.DataPath(true, false, false), base.cacheName));
			}
		}

		protected override void OnSaveToLocal()
		{
			base.OnSaveToLocal();
			string path = Path.Combine(UtilHelper.DataPath(true, false, false), base.cacheName);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.WriteAllBytes(Path.Combine(UtilHelper.DataPath(true, false, false), base.cacheName), base.www.bytes);
		}
	}
}
