using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnMouseEnter",
		"OnMouseExit",
		"OnMouseOver"
	}), Category("System Events"), Name("Check Mouse 2D")]
	public class CheckMouse2D : ConditionTask<Collider2D>
	{
		public MouseInteractionTypes checkType;

		protected override string info
		{
			get
			{
				return this.checkType.ToString();
			}
		}

		protected override bool OnCheck()
		{
			return false;
		}

		public void OnMouseEnter()
		{
			if (this.checkType == MouseInteractionTypes.MouseEnter)
			{
				base.YieldReturn(true);
			}
		}

		public void OnMouseExit()
		{
			if (this.checkType == MouseInteractionTypes.MouseExit)
			{
				base.YieldReturn(true);
			}
		}

		public void OnMouseOver()
		{
			if (this.checkType == MouseInteractionTypes.MouseOver)
			{
				base.YieldReturn(true);
			}
		}
	}
}
