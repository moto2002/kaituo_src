using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	public class IsActive : ConditionTask<Transform>
	{
		protected override bool OnCheck()
		{
			return base.agent.gameObject.activeInHierarchy;
		}
	}
}
