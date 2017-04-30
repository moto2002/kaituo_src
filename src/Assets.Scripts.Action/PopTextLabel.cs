using Assets.Migration.Scripts.Anim;
using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Helper;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("obsolete/Effect"), Name("Pop label")]
	public class PopTextLabel : DevisableAction
	{
		public enum PopTextType
		{
			Hp,
			Text,
			Int,
			Float
		}

		public BBParameter<GameObject> Prefab;

		public PopTextLabel.PopTextType Type;

		public BBParameter<string> Text;

		public BBParameter<int> Hp;

		public BBParameter<int> IntNum;

		public BBParameter<float> FloatNum;

		public BBParameter<GameObject> Target;

		private TextLabelAnim TextAnim;

		protected override void OnExecute()
		{
			GameObject value = this.Target.value;
			GameObject value2 = this.Prefab.value;
			GameObject gameObject = value.AddInstantiate(value2);
			this.TextAnim = gameObject.GetComponent<TextLabelAnim>();
			this.TextAnim.Show(this.GetMsg());
		}

		protected override void OnUpdate()
		{
			if (this.TextAnim == null)
			{
				base.EndAction();
			}
		}

		private string GetMsg()
		{
			switch (this.Type)
			{
			case PopTextLabel.PopTextType.Hp:
			{
				int value = this.Hp.value;
				if (value > 0)
				{
					return "+" + value;
				}
				return value.ToString();
			}
			case PopTextLabel.PopTextType.Text:
				return this.Text.value;
			case PopTextLabel.PopTextType.Int:
				return this.IntNum.value.ToString();
			case PopTextLabel.PopTextType.Float:
				return this.FloatNum.value.ToString();
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
