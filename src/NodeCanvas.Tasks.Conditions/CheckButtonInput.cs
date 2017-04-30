using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input")]
	public class CheckButtonInput : ConditionTask
	{
		public PressTypes pressType;

		[RequiredField]
		public BBParameter<string> buttonName = "Fire1";

		protected override string info
		{
			get
			{
				return this.pressType.ToString() + " " + this.buttonName.ToString();
			}
		}

		protected override bool OnCheck()
		{
			if (this.pressType == PressTypes.Down)
			{
				return Input.GetButtonDown(this.buttonName.value);
			}
			if (this.pressType == PressTypes.Up)
			{
				return Input.GetButtonUp(this.buttonName.value);
			}
			return this.pressType == PressTypes.Pressed && Input.GetButton(this.buttonName.value);
		}
	}
}
