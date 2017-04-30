using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnTriggerEnter2D",
		"OnTriggerExit2D"
	}), Category("System Events"), Name("Check Trigger 2D")]
	public class CheckTrigger2D : ConditionTask<Collider2D>
	{
		public TriggerTypes CheckType;

		public bool specifiedTagOnly;

		[TagField]
		public string objectTag = "Untagged";

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		private bool stay;

		protected override string info
		{
			get
			{
				return this.CheckType.ToString() + ((!this.specifiedTagOnly) ? string.Empty : (" '" + this.objectTag + "' tag"));
			}
		}

		protected override bool OnCheck()
		{
			return this.CheckType == TriggerTypes.TriggerStay && this.stay;
		}

		public void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.specifiedTagOnly || other.gameObject.tag == this.objectTag)
			{
				this.stay = true;
				if (this.CheckType == TriggerTypes.TriggerEnter || this.CheckType == TriggerTypes.TriggerStay)
				{
					this.saveGameObjectAs.value = other.gameObject;
					base.YieldReturn(true);
				}
			}
		}

		public void OnTriggerExit2D(Collider2D other)
		{
			if (!this.specifiedTagOnly || other.gameObject.tag == this.objectTag)
			{
				this.stay = false;
				if (this.CheckType == TriggerTypes.TriggerExit)
				{
					this.saveGameObjectAs.value = other.gameObject;
					base.YieldReturn(true);
				}
			}
		}
	}
}
