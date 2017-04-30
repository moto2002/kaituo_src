using System;

namespace ParadoxNotion
{
	public class EventData
	{
		public string name;

		public EventData(string name)
		{
			this.name = name;
		}
	}
	public class EventData<T> : EventData
	{
		public T value;

		public EventData(string name, T value) : base(name)
		{
			this.value = value;
		}
	}
}
