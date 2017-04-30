using System;

namespace Assets.Script.Mvc
{
	public static class EventHelper
	{
		public static T GetData<T>(this IEvent e)
		{
			Event<T> @event = e as Event<T>;
			return @event.Data;
		}

		public static T GetData<T>(this IEvent e, string name)
		{
			HashDataEvent hashDataEvent = e as HashDataEvent;
			return hashDataEvent.Get<T>(name);
		}

		public static T As<T>(this IEvent e) where T : IEvent
		{
			return e as T;
		}
	}
}
