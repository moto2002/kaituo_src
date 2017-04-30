using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("UGUI")]
	public class ButtonClicked : ConditionTask
	{
		[RequiredField]
		public BBParameter<Button> button;

		protected override string info
		{
			get
			{
				return string.Format("Button {0} Clicked", this.button.ToString());
			}
		}

		protected override string OnInit()
		{
			this.button.value.onClick.AddListener(new UnityAction(this.OnClick));
			return null;
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void OnClick()
		{
			base.YieldReturn(true);
		}
	}
}
