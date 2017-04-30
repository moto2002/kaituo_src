using ParadoxNotion;
using System;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public interface ITaskSystem
	{
		Component agent
		{
			get;
		}

		IBlackboard blackboard
		{
			get;
		}

		float elapsedTime
		{
			get;
		}

		UnityEngine.Object baseObject
		{
			get;
		}

		void SendTaskOwnerDefaults();

		void SendEvent(EventData eventData);
	}
}
