using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Name("Set Visibility")]
	public class SetObjectActive : ActionTask<Transform>
	{
		public enum SetActiveMode
		{
			Deactivate,
			Activate,
			Toggle
		}

		public SetObjectActive.SetActiveMode setTo = SetObjectActive.SetActiveMode.Toggle;

		protected override string info
		{
			get
			{
				return string.Format("{0} GameObject", this.setTo.ToString());
			}
		}

		protected override void OnExecute()
		{
			bool active;
			if (this.setTo == SetObjectActive.SetActiveMode.Toggle)
			{
				active = !base.agent.gameObject.activeSelf;
			}
			else
			{
				active = (this.setTo == SetObjectActive.SetActiveMode.Activate);
			}
			base.agent.gameObject.SetActive(active);
			base.EndAction();
		}
	}
}
