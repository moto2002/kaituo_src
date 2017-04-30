using Assets.Scripts.Action.Core;
using Assets.Tools.Script.Helper;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action.General
{
	[Category("obsolete/General"), Name("GameObject layer")]
	public class GameObjectLayerAction : DevisableAction
	{
		public BBParameter<GameObject> Target;

		public LayerMask Layer;

		protected override void OnExecute()
		{
			int layer;
			bool flag = LayerMaskExtension.ValueToLayer.TryGetValue((uint)this.Layer.value, out layer);
			if (flag)
			{
				this.Target.value.SetLayerWidthChildren(layer);
			}
			base.EndAction();
		}
	}
}
