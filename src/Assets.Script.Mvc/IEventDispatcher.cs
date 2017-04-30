using System;

namespace Assets.Script.Mvc
{
	public interface IEventDispatcher : ICommandEventDispatcher, IModelEventDispatcher, IViewEventDispatcher
	{
	}
}
