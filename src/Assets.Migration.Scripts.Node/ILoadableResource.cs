using Assets.Tools.Script.Event;
using System;

namespace Assets.Migration.Scripts.Node
{
	public interface ILoadableResource
	{
		Signal<ILoadableResource> LoadCompleteSignal
		{
			get;
		}

		void Load();
	}
}
