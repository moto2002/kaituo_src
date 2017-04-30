using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace Assets.Scripts.Action
{
	[Category("✫ GOG/Process"), Name("Change time scale")]
	public class ChangeTimeScale : ActionTask
	{
		public AnimationCurve Curve;

		private float playTime;

		private DateTime startDataTime;

		private float RunTime
		{
			get
			{
				return (float)(DateTime.Now - this.startDataTime).TotalSeconds;
			}
		}

		protected override void OnExecute()
		{
			this.startDataTime = DateTime.Now;
			if (this.Curve.keys.Length < 2)
			{
				base.EndAction();
			}
			else
			{
				this.playTime = this.Curve.keys[this.Curve.keys.Length - 1].time;
			}
		}

		protected override void OnUpdate()
		{
			float runTime = this.RunTime;
			if (this.playTime > runTime)
			{
				float timeScale = this.Curve.Evaluate(runTime);
				Time.timeScale = timeScale;
			}
			else
			{
				base.EndAction();
			}
		}
	}
}
