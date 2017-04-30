using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnMouseDown",
		"OnMouseUp"
	}), Category("System Events")]
	public class CheckMouseClick : ConditionTask<Collider>
	{
		public MouseClickEvent checkType;

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

		public void OnMouseDown()
		{
			if (this.checkType == MouseClickEvent.MouseDown)
			{
				base.YieldReturn(true);
			}
		}

		public void OnMouseUp()
		{
			if (this.checkType == MouseClickEvent.MouseUp)
			{
				base.YieldReturn(true);
			}
		}
	}
}
