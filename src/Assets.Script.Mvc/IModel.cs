using System;

namespace Assets.Script.Mvc
{
	public interface IModel
	{
		IModelEventDispatcher EventDispatcher
		{
			get;
			set;
		}

		MvcContext Context
		{
			get;
			set;
		}

		void OnRegister();

		void OnUnRegister();
	}
}
