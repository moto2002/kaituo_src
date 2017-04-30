using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Animation")]
	public class PlayAnimationAdvanced : ActionTask<Animation>
	{
		[RequiredField]
		public BBParameter<AnimationClip> animationClip;

		public WrapMode animationWrap;

		public AnimationBlendMode blendMode;

		[SliderField(0, 2)]
		public float playbackSpeed = 1f;

		[SliderField(0, 1)]
		public float crossFadeTime = 0.25f;

		public PlayDirections playDirection;

		public BBParameter<string> mixTransformName;

		public BBParameter<int> animationLayer;

		public bool queueAnimation;

		public bool waitActionFinish = true;

		private string animationToPlay = string.Empty;

		private int dir = -1;

		private Transform mixTransform;

		protected override string info
		{
			get
			{
				return "Anim " + this.animationClip.ToString();
			}
		}

		protected override void OnExecute()
		{
			if (this.playDirection == PlayDirections.Toggle)
			{
				this.dir = -this.dir;
			}
			if (this.playDirection == PlayDirections.Backward)
			{
				this.dir = -1;
			}
			if (this.playDirection == PlayDirections.Forward)
			{
				this.dir = 1;
			}
			base.agent.AddClip(this.animationClip.value, this.animationClip.value.name);
			this.animationToPlay = this.animationClip.value.name;
			if (!string.IsNullOrEmpty(this.mixTransformName.value))
			{
				this.mixTransform = this.FindTransform(base.agent.transform, this.mixTransformName.value);
				if (!this.mixTransform)
				{
					Debug.LogWarning("Cant find transform with name '" + this.mixTransformName.value + "' for PlayAnimation Action");
				}
			}
			else
			{
				this.mixTransform = null;
			}
			this.animationToPlay = this.animationClip.value.name;
			if (this.mixTransform)
			{
				base.agent[this.animationToPlay].AddMixingTransform(this.mixTransform, true);
			}
			base.agent[this.animationToPlay].layer = this.animationLayer.value;
			base.agent[this.animationToPlay].speed = (float)this.dir * this.playbackSpeed;
			base.agent[this.animationToPlay].normalizedTime = Mathf.Clamp01((float)(-(float)this.dir));
			base.agent[this.animationToPlay].wrapMode = this.animationWrap;
			base.agent[this.animationToPlay].blendMode = this.blendMode;
			if (this.queueAnimation)
			{
				base.agent.CrossFadeQueued(this.animationToPlay, this.crossFadeTime);
			}
			else
			{
				base.agent.CrossFade(this.animationToPlay, this.crossFadeTime);
			}
			if (!this.waitActionFinish)
			{
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= base.agent[this.animationToPlay].length / this.playbackSpeed - this.crossFadeTime)
			{
				base.EndAction(new bool?(true));
			}
		}

		private Transform FindTransform(Transform parent, string name)
		{
			if (parent.name == name)
			{
				return parent;
			}
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			Transform[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				Transform transform = array[i];
				if (transform.name == name)
				{
					return transform;
				}
			}
			return null;
		}
	}
}
