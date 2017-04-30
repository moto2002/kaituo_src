using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Audio")]
	public class PlayAudioAtPosition : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<AudioClip> audioClip;

		[SliderField(0, 1)]
		public float volume = 1f;

		public bool waitActionFinish;

		protected override string info
		{
			get
			{
				return "PlayAudio " + this.audioClip.ToString();
			}
		}

		protected override void OnExecute()
		{
			AudioSource.PlayClipAtPoint(this.audioClip.value, base.agent.position, this.volume);
			if (!this.waitActionFinish)
			{
				base.EndAction();
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= this.audioClip.value.length)
			{
				base.EndAction();
			}
		}
	}
}
