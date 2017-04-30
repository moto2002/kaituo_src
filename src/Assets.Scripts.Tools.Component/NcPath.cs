using Jacovone;
using System;
using UnityEngine;

namespace Assets.Scripts.Tools.Component
{
	public class NcPath : NcEffectAniBehaviour
	{
		public PathMagic PathMagic;

		public Transform Target;

		public float fDelayTime;

		public bool xScale = true;

		public bool yScale;

		public bool zScale;

		public bool speedScale;

		public GameObject[] OnEndActiveGameObjects;

		public float OnEndActiveDelay;

		public GameObject[] OnEndDisactiveGameObjects;

		public float OnEndDisactiveDelay;

		private float velocityBias = -1f;

		private float startTime = -1f;

		public void SetScale(float scale)
		{
			if (this.velocityBias < 0f)
			{
				this.velocityBias = this.PathMagic.VelocityBias;
			}
			this.PathMagic.VelocityBias = ((!this.speedScale) ? this.velocityBias : (this.velocityBias / scale));
			base.transform.localScale = new Vector3((!this.xScale) ? 1f : scale, (!this.yScale) ? 1f : scale, (!this.zScale) ? 1f : scale);
		}

		public override void ResetAnimation()
		{
			base.ResetAnimation();
			this.SetActive(this.OnEndActiveGameObjects, false);
			this.SetActive(this.OnEndDisactiveGameObjects, true);
			this.startTime = -1f;
			this.PathMagic.OnStopPlay = new Action(this.OnStopPlay);
			this.PathMagic.Target = this.Target;
			this.PathMagic.CurrentPos = 0f;
			this.PathMagic.Stop();
			if (this.fDelayTime >= 0f)
			{
				base.Invoke("StartPlayPath", this.fDelayTime);
			}
			else
			{
				this.StartPlayPath();
			}
		}

		private void OnDisable()
		{
			base.CancelInvoke("StartPlayPath");
		}

		public override void PauseAnimation()
		{
			this.PathMagic.Pause();
			base.PauseAnimation();
		}

		public override void ResumeAnimation()
		{
			this.PathMagic.Play();
			base.ResumeAnimation();
		}

		private void StartPlayPath()
		{
			this.startTime = Time.time;
			this.PathMagic.Play();
		}

		private void OnStopPlay()
		{
			if (this.startTime > 0f)
			{
				DebugConsole.LogToChannel(22, new object[]
				{
					Time.time - this.startTime
				});
				this.startTime = -1f;
				if (this.OnEndActiveDelay > 0f)
				{
					base.Invoke("DelayActive", this.OnEndActiveDelay);
				}
				else
				{
					this.DelayActive();
				}
				if (this.OnEndDisactiveDelay > 0f)
				{
					base.Invoke("DelayDisActive", this.OnEndDisactiveDelay);
				}
				else
				{
					this.DelayDisActive();
				}
			}
		}

		private void DelayActive()
		{
			this.SetActive(this.OnEndActiveGameObjects, true);
		}

		private void DelayDisActive()
		{
			this.SetActive(this.OnEndDisactiveGameObjects, false);
		}

		private void SetActive(GameObject[] list, bool active)
		{
			if (list != null && list.Length > 0)
			{
				for (int i = 0; i < list.Length; i++)
				{
					GameObject gameObject = list[i];
					gameObject.SetActive(active);
				}
			}
		}
	}
}
