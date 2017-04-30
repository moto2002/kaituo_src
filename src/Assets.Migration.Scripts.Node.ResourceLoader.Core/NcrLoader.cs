using Assets.Tools.Script.Event;
using NodeCanvas.Framework;
using System;

namespace Assets.Migration.Scripts.Node.ResourceLoader.Core
{
	public abstract class NcrLoader
	{
		public Signal<NcrLoader> OnLoadCompleteSignal = new Signal<NcrLoader>();

		protected IBlackboard blackboard;

		public void Append(NcrData data)
		{
			this.OnAppend(data);
		}

		protected abstract void OnAppend(NcrData data);

		public void StartLoad(IBlackboard blackboard)
		{
			this.blackboard = blackboard;
			this.OnStartLoad();
		}

		public virtual void Clear()
		{
			this.blackboard = null;
		}

		protected abstract void OnStartLoad();
	}
}
