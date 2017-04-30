using Assets.Tools.Script.Sound;
using System;
using UnityEngine;

public class SoundCenter : MonoBehaviour, IGameVolume
{
	[SerializeField]
	private float effSound = 1f;

	[SerializeField]
	private float BkSound = 1f;

	public float backgroundSound
	{
		get
		{
			return this.BkSound;
		}
		set
		{
			this.BkSound = value;
		}
	}

	public float effectSound
	{
		get
		{
			return this.effSound;
		}
		set
		{
			this.effSound = value;
		}
	}

	private void Start()
	{
		SoundUtilities.volumeCentre = this;
	}

	public void SetBackgroundSound(float sound)
	{
		this.backgroundSound = sound;
	}

	public void SetEffectSound(float sound)
	{
		this.effectSound = sound;
	}
}
