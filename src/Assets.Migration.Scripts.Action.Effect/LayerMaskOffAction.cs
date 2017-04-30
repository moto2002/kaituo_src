using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("obsolete/Effect"), Name("Layer Mask Off")]
	public class LayerMaskOffAction : ActionTask
	{
		protected override void OnExecute()
		{
			GameObject gameObject = GameObject.Find(LayerMaskAction.TAG_LAYERMASK_CONTROLLER);
			if (gameObject != null)
			{
				LayerMaskBehavior component = gameObject.GetComponent<LayerMaskBehavior>();
				if (component != null)
				{
					component.StopMask();
				}
				gameObject.SetActive(false);
			}
			base.EndAction(new bool?(true));
		}
	}
}
