using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using System;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility"), Description("Send a graph event. If global is true, all graph owners in scene will receive this event. Use along with the 'Check Event' Condition")]
	public class SendEvent : ActionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<float> delay;

		public bool sendGlobal;

		protected override string info
		{
			get
			{
				return string.Concat(new object[]
				{
					(!this.sendGlobal) ? string.Empty : "Global ",
					"Send Event [",
					this.eventName,
					"]",
					(this.delay.value <= 0f) ? string.Empty : (" after " + this.delay + " sec.")
				});
			}
		}

		protected override string OnInit()
		{
			if (base.agent.GetComponent<MessageRouter>() == null)
			{
				base.agent.gameObject.AddComponent<MessageRouter>();
			}
			return null;
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime > this.delay.value)
			{
				if (this.sendGlobal)
				{
					Graph.SendGlobalEvent(new EventData(this.eventName.value));
				}
				else
				{
					base.agent.SendEvent(new EventData(this.eventName.value));
				}
				base.EndAction();
			}
		}
	}
	[Category("✫ Utility"), Description("Send a graph event with T value. If global is true, all graph owners in scene will receive this event. Use along with the 'Check Event' Condition")]
	public class SendEvent<T> : ActionTask<GraphOwner>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<T> eventValue;

		public BBParameter<float> delay;

		public bool sendGlobal;

		protected override string info
		{
			get
			{
				return string.Format("{0} Event [{1}] ({2}){3}", new object[]
				{
					(!this.sendGlobal) ? string.Empty : "Global ",
					this.eventName,
					this.eventValue,
					(this.delay.value <= 0f) ? string.Empty : (" after " + this.delay + " sec.")
				});
			}
		}

		protected override string OnInit()
		{
			if (base.agent.GetComponent<MessageRouter>() == null)
			{
				base.agent.gameObject.AddComponent<MessageRouter>();
			}
			return null;
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime > this.delay.value)
			{
				if (this.sendGlobal)
				{
					Graph.SendGlobalEvent(new EventData<T>(this.eventName.value, this.eventValue.value));
				}
				else
				{
					base.agent.SendEvent(new EventData<T>(this.eventName.value, this.eventValue.value));
				}
				base.EndAction();
			}
		}
	}
}
