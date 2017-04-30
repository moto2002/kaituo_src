using System;

namespace Assets.Script.Mvc
{
	public abstract class Model : IModel
	{
		public IModelEventDispatcher EventDispatcher
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
