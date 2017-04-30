using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("✫ GOG/Effect"), Name("Switch Material")]
	public class SwitchMaterialAction : ActionTask
	{
		public BBParameter<GameObject> TargetGameObject;

		public BBParameter<LayerMask> Layer;

		public BBParameter<Material> ToMaterial;

		public BBParameter<float> AutoRestoreSeconds;

		private bool startExecuting;

		private float startTime = 3.40282347E+38f;

		protected override void OnExecute()
		{
			if (this.TargetGameObject.value != null)
			{
				GameObject value = this.TargetGameObject.value;
				SwitchMaterialBehavior switchMaterialBehavior = value.GetComponent<SwitchMaterialBehavior>();
				if (switchMaterialBehavior == null)
				{
					switchMaterialBehavior = value.AddComponent<SwitchMaterialBehavior>();
				}
				switchMaterialBehavior.Switch(this.ToMaterial.value, this.Layer.value, this.AutoRestoreSeconds.value);
				if (this.AutoRestoreSeconds.value > 0f)
				{
					this.startExecuting = true;
					this.startTime = Time.realtimeSinceStartup;
				}
				else
				{
					base.EndAction(new bool?(true));
				}
			}
			else
			{
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnUpdate()
		{
			if (this.startExecuting && Time.realtimeSinceStartup - this.startTime > this.AutoRestoreSeconds.value)
			{
				this.startExecuting = false;
				this.startTime = 3.40282347E+38f;
				base.EndAction(new bool?(true));
			}
		}
	}
}
