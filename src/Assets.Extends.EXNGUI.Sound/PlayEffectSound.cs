using Assets.Tools.Script.Sound;
using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Sound
{
	public class PlayEffectSound : MonoBehaviour
	{
		public enum Trigger
		{
			OnClick,
			OnMouseOver,
			OnMouseOut,
			OnPress,
			OnRelease,
			Custom,
			OnStart
		}

		public AudioClip audioClip;

		public PlayEffectSound.Trigger trigger;

		private bool mIsOver;

		private void OnHover(bool isOver)
		{
			if (this.trigger == PlayEffectSound.Trigger.OnMouseOver)
			{
				if (this.mIsOver == isOver)
				{
					return;
				}
				this.mIsOver = isOver;
			}
			if (base.enabled && ((isOver && this.trigger == PlayEffectSound.Trigger.OnMouseOver) || (!isOver && this.trigger == PlayEffectSound.Trigger.OnMouseOut)))
			{
				EffectSoundPlayer.PlaySound(this.audioClip);
			}
		}

		private void OnPress(bool isPressed)
		{
			if (this.trigger == PlayEffectSound.Trigger.OnPress)
			{
				if (this.mIsOver == isPressed)
				{
					return;
				}
				this.mIsOver = isPressed;
			}
			if (base.enabled && ((isPressed && this.trigger == PlayEffectSound.Trigger.OnPress) || (!isPressed && this.trigger == PlayEffectSound.Trigger.OnRelease)))
			{
				EffectSoundPlayer.PlaySound(this.audioClip);
			}
		}

		private void OnClick()
		{
			if (base.enabled && this.trigger == PlayEffectSound.Trigger.OnClick)
			{
				EffectSoundPlayer.PlaySound(this.audioClip);
			}
		}

		private void Start()
		{
			if (base.enabled && this.trigger == PlayEffectSound.Trigger.OnStart)
			{
				EffectSoundPlayer.PlaySound(this.audioClip);
			}
		}

		private void OnSelect(bool isSelected)
		{
			if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
			{
				this.OnHover(isSelected);
			}
		}

		public void Play()
		{
			if (base.enabled && base.gameObject.activeInHierarchy)
			{
				EffectSoundPlayer.PlaySound(this.audioClip);
			}
		}
	}
}
