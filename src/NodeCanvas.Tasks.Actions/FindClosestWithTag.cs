using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("GameObject"), Description("Find the closest game object of tag to the agent")]
	public class FindClosestWithTag : ActionTask<Transform>
	{
		[RequiredField, TagField]
		public BBParameter<string> searchTag;

		[BlackboardOnly]
		public BBParameter<GameObject> saveObjectAs;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		protected override void OnExecute()
		{
			List<GameObject> list = GameObject.FindGameObjectsWithTag(this.searchTag.value).ToList<GameObject>();
			if (list.Count == 0)
			{
				this.saveObjectAs.value = null;
				this.saveDistanceAs.value = 0f;
				base.EndAction(new bool?(false));
				return;
			}
			GameObject value = null;
			float num = float.PositiveInfinity;
			foreach (GameObject current in list)
			{
				if (!(current == base.agent.gameObject))
				{
					float num2 = Vector3.Distance(current.transform.position, base.agent.position);
					if (num2 < num)
					{
						num = num2;
						value = current;
					}
				}
			}
			this.saveObjectAs.value = value;
			this.saveDistanceAs.value = num;
			base.EndAction();
		}
	}
}
