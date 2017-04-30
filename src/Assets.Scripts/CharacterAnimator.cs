using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class CharacterAnimator : MonoBehaviour
	{
		public RpgCharacter Character;

		public AnimationClip LastAnimClip;

		public AnimationState LastAnimState;

		public Action<CharacterAnimator, string> OnAnimationEvent;

		public Animation animation;

		private float prePlayTime;

		private float endTime;

		private bool isEndAtFrame;

		private bool isPlaying;

		private float pauseSpeed;

		public void AnimationEvent(string eventName)
		{
			if (eventName == "Hit")
			{
				this.OnAttack();
			}
			if (this.OnAnimationEvent != null)
			{
				this.OnAnimationEvent(this, eventName);
			}
		}

		public AnimationClip Play(string animName)
		{
			this.prePlayTime = 0f;
			this.animation.Stop();
			if (this.LastAnimClip != null && this.LastAnimClip.name == animName)
			{
				this.animation.Stop();
			}
			this.LastAnimClip = this.animation.GetClip(animName);
			this.LastAnimState = this.animation[animName];
			if (this.LastAnimClip == null)
			{
				return null;
			}
			if (this.LastAnimClip.wrapMode != WrapMode.Loop)
			{
				this.endTime = this.LastAnimClip.length;
			}
			else
			{
				this.endTime = 0f;
			}
			this.isEndAtFrame = false;
			this.PlayAnim(animName);
			return this.LastAnimClip;
		}

		public void StopAnim()
		{
			bool flag = this.endTime > 0f;
			this.OnStop();
			this.animation.Stop();
			if (flag)
			{
				this.Character.OnAnimEndSignal.Dispatch(this);
			}
		}

		public AnimationClip GotoAndPlay(string animName, float time)
		{
			AnimationClip result = this.Play(animName);
			this.LastAnimState.time = time;
			return result;
		}

		public AnimationClip GotoAndStop(string animName, float time)
		{
			AnimationClip result = this.Play(animName);
			this.LastAnimState.time = time;
			this.endTime = time;
			this.isEndAtFrame = true;
			return result;
		}

		public AnimationClip PlayTo(string animName, float time)
		{
			AnimationClip result = this.Play(animName);
			if (this.LastAnimClip.wrapMode != WrapMode.Loop)
			{
				this.endTime = time;
			}
			this.isEndAtFrame = true;
			return result;
		}

		public AnimationClip PlayBetween(string animName, float from, float to)
		{
			AnimationClip result = this.GotoAndPlay(animName, from);
			if (this.LastAnimClip.wrapMode != WrapMode.Loop)
			{
				this.endTime = to;
			}
			this.isEndAtFrame = true;
			return result;
		}

		public void ChangeSpeed(float speed)
		{
			this.LastAnimState.speed = speed;
		}

		public void PauseAnim()
		{
			this.pauseSpeed = this.LastAnimState.speed;
			this.LastAnimState.speed = 0f;
		}

		public void ResumeAnim()
		{
			this.LastAnimState.speed = this.pauseSpeed;
		}

		public List<string> GetAnimationNames()
		{
			List<string> list = new List<string>();
			foreach (object current in this.animation)
			{
				AnimationState animationState = current as AnimationState;
				list.Add(animationState.name);
			}
			return list;
		}

		private void LateUpdate()
		{
			if (this.isPlaying)
			{
				if (this.endTime > 0f && (this.LastAnimState.time >= this.endTime || (Math.Abs(this.LastAnimState.time) < 0.001f && this.prePlayTime > 0f)))
				{
					if (this.isEndAtFrame)
					{
						this.StopAnim();
					}
					else
					{
						this.OnAnimEnd();
					}
				}
				this.prePlayTime = this.LastAnimState.time;
			}
		}

		private void PlayAnim(string animName)
		{
			if (this.endTime > 0f)
			{
				this.isPlaying = true;
			}
			this.animation.Play(animName);
		}

		private void OnStop()
		{
			this.isPlaying = false;
			this.endTime = 0f;
			this.prePlayTime = 0f;
			this.isEndAtFrame = false;
		}

		private void OnAnimEnd()
		{
			this.OnStop();
			this.Character.OnAnimEndSignal.Dispatch(this);
		}

		private void OnAttack()
		{
			this.Character.OnAttackSignal.Dispatch(this.Character);
		}
	}
}
