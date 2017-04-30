using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Script Control/Common"), Description("Will subscribe to a public event of Action type and return true when the event is raised.\n(eg public static event System.Action [name])")]
	public class CheckStaticCSharpEvent : ConditionTask
	{
		[SerializeField]
		private Type targetType;

		[SerializeField]
		private string eventName;

		protected override string info
		{
			get
			{
				if (string.IsNullOrEmpty(this.eventName))
				{
					return "No Event Selected";
				}
				return string.Format("'{0}' Raised", this.eventName);
			}
		}

		protected override string OnInit()
		{
			if (this.eventName == null)
			{
				return "No Event Selected";
			}
			EventInfo eventInfo = this.targetType.RTGetEvent(this.eventName);
			if (eventInfo == null)
			{
				return "Event was not found";
			}
			Action handler = delegate
			{
				this.Raised();
			};
			eventInfo.AddEventHandler(null, handler);
			return null;
		}

		public void Raised()
		{
			base.YieldReturn(true);
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
	[Category("✫ Script Control/Common"), Description("Will subscribe to a public event of Action type and return true when the event is raised.\n(eg public static event System.Action<T> [name])")]
	public class CheckStaticCSharpEvent<T> : ConditionTask
	{
		[SerializeField]
		private Type targetType;

		[SerializeField]
		private string eventName;

		[BlackboardOnly, SerializeField]
		private BBParameter<T> saveAs;

		protected override string info
		{
			get
			{
				if (string.IsNullOrEmpty(this.eventName))
				{
					return "No Event Selected";
				}
				return string.Format("'{0}' Raised", this.eventName);
			}
		}

		protected override string OnInit()
		{
			if (this.eventName == null)
			{
				return "No Event Selected";
			}
			EventInfo eventInfo = this.targetType.RTGetEvent(this.eventName);
			if (eventInfo == null)
			{
				return "Event was not found";
			}
			Action<T> handler = delegate(T v)
			{
				this.Raised(v);
			};
			eventInfo.AddEventHandler(null, handler);
			return null;
		}

		public void Raised(T eventValue)
		{
			this.saveAs.value = eventValue;
			base.YieldReturn(true);
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
