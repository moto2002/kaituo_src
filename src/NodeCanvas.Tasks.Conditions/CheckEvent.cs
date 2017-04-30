using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnCustomEvent"
	}), Category("✫ Utility"), Description("Check if an event is received and return true for one frame")]
	public class CheckEvent : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		protected override string info
		{
			get
			{
				return "[" + this.eventName.ToString() + "]";
			}
		}

		protected override bool OnCheck()
		{
			return false;
		}

		public void OnCustomEvent(EventData receivedEvent)
		{
			if (receivedEvent.name == this.eventName.value)
			{
				Debug.Log(string.Format("<b>Event Received from ({0}): </b> '{1}'", base.agent.name, receivedEvent.name));
				base.YieldReturn(true);
			}
		}
	}
	[Task.EventReceiverAttribute(new string[]
	{
		"OnCustomEvent"
	}), Category("✫ Utility"), Description("Check if an event is received and return true for one frame. Optionaly save the received event's value")]
	public class CheckEvent<T> : ConditionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		[BlackboardOnly]
		public BBParameter<T> saveEventValue;

		protected override string info
		{
			get
			{
				return string.Format("Event [{0}]\n{1} = EventValue", this.eventName, this.saveEventValue);
			}
		}

		protected override bool OnCheck()
		{
			return false;
		}

		public void OnCustomEvent(EventData receivedEvent)
		{
			if (receivedEvent.name == this.eventName.value)
			{
				Debug.Log(string.Format("<b>Event Received from ({0}): </b> '{1}'", base.agent.name, receivedEvent.name));
				if (receivedEvent is EventData<T>)
				{
					this.saveEventValue.value = (receivedEvent as EventData<T>).value;
				}
				else
				{
					Debug.Log(string.Format("Event received is of different value type than the specified '{0}'", typeof(T).FriendlyName()));
				}
				base.YieldReturn(true);
			}
		}
	}
}
