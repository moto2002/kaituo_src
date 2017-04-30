using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Task.EventReceiverAttribute(new string[]
	{
		"OnCollisionEnter",
		"OnCollisionExit"
	}), Category("System Events")]
	public class CheckCollision : ConditionTask<Collider>
	{
		public CollisionTypes checkType;

		public bool specifiedTagOnly;

		[TagField]
		public string objectTag = "Untagged";

		[BlackboardOnly]
		public BBParameter<GameObject> saveGameObjectAs;

		[BlackboardOnly]
		public BBParameter<Vector3> saveContactPoint;

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
			return this.checkType == CollisionTypes.CollisionStay && this.stay;
		}

		public void OnCollisionEnter(Collision info)
		{
			if (!this.specifiedTagOnly || info.gameObject.tag == this.objectTag)
			{
				this.stay = true;
				if (this.checkType == CollisionTypes.CollisionEnter || this.checkType == CollisionTypes.CollisionStay)
				{
					this.saveGameObjectAs.value = info.gameObject;
					this.saveContactPoint.value = info.contacts[0].point;
					base.YieldReturn(true);
				}
			}
		}

		public void OnCollisionExit(Collision info)
		{
			if (!this.specifiedTagOnly || info.gameObject.tag == this.objectTag)
			{
				this.stay = false;
				if (this.checkType == CollisionTypes.CollisionExit)
				{
					this.saveGameObjectAs.value = info.gameObject;
					base.YieldReturn(true);
				}
			}
		}
	}
}
