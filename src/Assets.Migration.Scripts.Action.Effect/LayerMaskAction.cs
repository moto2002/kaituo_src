using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Migration.Scripts.Action.Effect
{
	[Category("obsolete/Effect"), Name("Layer Mask")]
	public class LayerMaskAction : ActionTask
	{
		public BBParameter<Camera> TargetCamera;

		public BBParameter<LayerMask> CullingMask;

		public BBParameter<Color> MaskColor;

		public BBParameter<int> MaskTextureSize;

		public BBParameter<float> ElaspedSeconds;

		public static string TAG_LAYERMASK_CONTROLLER = "__layer_mask_controller";

		private bool startExecuting;

		private float startTime = 3.40282347E+38f;

		protected override void OnExecute()
		{
			GameObject gameObject = GameObject.Find(LayerMaskAction.TAG_LAYERMASK_CONTROLLER);
			LayerMaskBehavior layerMaskBehavior;
			if (gameObject == null)
			{
				gameObject = new GameObject(LayerMaskAction.TAG_LAYERMASK_CONTROLLER);
				gameObject.AddComponent<Camera>();
				layerMaskBehavior = gameObject.AddComponent<LayerMaskBehavior>();
			}
			else
			{
				layerMaskBehavior = gameObject.GetComponent<LayerMaskBehavior>();
			}
			layerMaskBehavior.StartMask(this.TargetCamera.value, this.CullingMask.value, this.MaskColor.value, this.MaskTextureSize.value, this.ElaspedSeconds.value);
			gameObject.SetActive(true);
			if (this.ElaspedSeconds.value > 0f)
			{
				this.startExecuting = true;
				this.startTime = Time.realtimeSinceStartup;
			}
			else
			{
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnUpdate()
		{
			if (this.startExecuting && Time.realtimeSinceStartup - this.startTime > this.ElaspedSeconds.value)
			{
				this.startTime = 3.40282347E+38f;
				base.EndAction(new bool?(true));
			}
		}
	}
}
