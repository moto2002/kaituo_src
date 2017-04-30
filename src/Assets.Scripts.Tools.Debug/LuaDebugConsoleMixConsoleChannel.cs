using System;
using System.Collections.Generic;

namespace Assets.Scripts.Tools.Debug
{
	[Serializable]
	public class LuaDebugConsoleMixConsoleChannel
	{
		public int ToChannel;

		public List<int> MixChannels = new List<int>();
	}
}
