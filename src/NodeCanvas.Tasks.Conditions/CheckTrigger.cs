using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnTriggerEnter",
		"OnTriggerExit"
	}), Category("System Events")]
	public class CheckTrigger : ConditionTask<Collider>
	{
		public TriggerTypes checkType;

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
				return this.checkType.ToString() + ((!this.specifiedTagOnly) ? string.Empty : (" '" + this.objectTag + "' tag"));
			}
		}

		protected override bool OnCheck()
		{
			return this.checkType == TriggerTypes.TriggerStay && this.stay;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (!this.specifiedTagOnly || other.gameObject.tag == this.objectTag)
			{
				this.stay = true;
				if (this.checkType == TriggerTypes.TriggerEnter || this.checkType == TriggerTypes.TriggerStay)
				{
					this.saveGameObjectAs.value = other.gameObject;
					base.YieldReturn(true);
				}
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (!this.specifiedTagOnly || other.gameObject.tag == this.objectTag)
			{
				this.stay = false;
				if (this.checkType == TriggerTypes.TriggerExit)
				{
					this.saveGameObjectAs.value = other.gameObject;
					base.YieldReturn(true);
				}
			}
		}
	}
}
