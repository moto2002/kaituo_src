using Assets.Tools.Script.File;
using System;

namespace Assets.Tools.Script.Net.Downloader
{
	public class MovLoader : LocalVersionEnableLoader
	{
		public MovLoader(string url, int version) : base(url, version)
		{
		}

		protected override string GetCacheName()
		{
			return "mov/" + base.GetCacheName() + ".mov";
		}

		protected override void LoadFromLocal()
		{
			try
			{
				base.LoadComplete();
			}
			catch (Exception)
			{
				ESFile.Delete(base.cacheName);
				throw;
			}
		}

		public override bool HasLocal()
		{
			return ESFile.Exists(base.cacheName);
		}

		protected override void OnSaveToLocal()
		{
			base.OnSaveToLocal();
			ESFile.SaveRaw(base.www.bytes, base.cacheName);
		}
	}
}
