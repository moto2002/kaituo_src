using System;

namespace Assets.Script.Mvc
{
	public abstract class View : IView
	{
		public IViewEventDispatcher EventDispatcher
		{
			get;
			set;
		}

		public MvcContext Context
		{
			get;
			set;
		}

		public virtual void OnRegister()
		{
		}

		public virtual void OnUnRegister()
		{
		}
	}
}
