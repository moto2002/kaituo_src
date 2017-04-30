using Assets.Tools.Script.Event;
using System;

namespace Assets.Tools.Script.Net.Downloader
{
	public interface ILoader
	{
		Signal<ILoader> onLoadStart
		{
			get;
		}

		Signal<ILoader> onLoadComplete
		{
			get;
		}

		Signal<ILoader> onLoadError
		{
			get;
		}

		Signal<ILoader> onUnloadLocalStart
		{
			get;
		}

		Signal<ILoader> onUnloadLocalComplete
		{
			get;
		}

		Signal<ILoader> onUnloadLocalError
		{
			get;
		}

		void Load(bool catchMemory = true);

		void Unload();

		void UnloadLocal();

		bool HasLocal();

		int GetLocalVersion();

		bool HasNewVersion();
	}
}
