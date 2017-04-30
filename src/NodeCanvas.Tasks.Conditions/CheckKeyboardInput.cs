using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input")]
	public class CheckKeyboardInput : ConditionTask
	{
		public PressTypes pressType;

		public KeyCode key = KeyCode.Space;

		protected override string info
		{
			get
			{
				return this.pressType.ToString() + " " + this.key.ToString();
			}
		}

		protected override bool OnCheck()
		{
			if (this.pressType == PressTypes.Down)
			{
				return Input.GetKeyDown(this.key);
			}
			if (this.pressType == PressTypes.Up)
			{
				return Input.GetKeyUp(this.key);
			}
			return this.pressType == PressTypes.Pressed && Input.GetKey(this.key);
		}
	}
}
