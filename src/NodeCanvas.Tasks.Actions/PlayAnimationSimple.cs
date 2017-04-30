using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Animation")]
	public class PlayAnimationSimple : ActionTask<Animation>
	{
		[RequiredField]
		public BBParameter<AnimationClip> animationClip;

		[SliderField(0, 1)]
		public float crossFadeTime = 0.25f;

		public WrapMode animationWrap = WrapMode.Loop;

		public bool waitActionFinish;

		private static readonly Dictionary<Animation, AnimationClip> lastPlayedClips = new Dictionary<Animation, AnimationClip>();

		protected override string info
		{
			get
			{
				return "Anim " + this.animationClip.ToString();
			}
		}

		protected override string OnInit()
		{
			base.agent.AddClip(this.animationClip.value, this.animationClip.value.name);
			return null;
		}

		protected override void OnExecute()
		{
			if (PlayAnimationSimple.lastPlayedClips.ContainsKey(base.agent) && PlayAnimationSimple.lastPlayedClips[base.agent] == this.animationClip.value)
			{
				base.EndAction(new bool?(true));
				return;
			}
			PlayAnimationSimple.lastPlayedClips[base.agent] = this.animationClip.value;
			base.agent[this.animationClip.value.name].wrapMode = this.animationWrap;
			base.agent.CrossFade(this.animationClip.value.name, this.crossFadeTime);
			if (!this.waitActionFinish)
			{
				base.EndAction(new bool?(true));
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.animationClip.value.length - this.crossFadeTime)
			{
				base.EndAction(new bool?(true));
			}
		}
	}
}
