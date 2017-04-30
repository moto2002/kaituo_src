using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Core.Input
{
	public class EventDelegateFunction : MonoBehaviour
	{
		[HideInInspector]
		public List<EventDelegate> EventDelegates = new List<EventDelegate>();

		public virtual string EventDelegateName()
		{
			return "call back";
		}

		public void CallDelegate()
		{
			EventDelegate.Execute(this.EventDelegates);
		}
	}
}
