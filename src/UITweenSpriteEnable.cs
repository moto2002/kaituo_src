using System;
using UnityEngine;

public class UITweenSpriteEnable : MonoBehaviour
{
	public int m_LoopCnt;

	public float m_Interval;

	public bool m_autoStart;

	private UISprite sprite;

	private int cnt;

	private void Awake()
	{
		this.sprite = base.GetComponent<UISprite>();
	}

	private void OnDisable()
	{
		this.cnt = 0;
		this.Stop();
	}

	private void OnEnable()
	{
		if (this.m_autoStart)
		{
			this.Play();
		}
	}

	public void Play()
	{
		this.Stop();
		base.InvokeRepeating("play", 0f, this.m_Interval);
	}

	public void Stop()
	{
		base.CancelInvoke("play");
	}

	private void play()
	{
		this.sprite.enabled = (++this.cnt % 2 == 0);
		if (this.m_LoopCnt > 0 && this.cnt == this.m_LoopCnt)
		{
			this.sprite.enabled = true;
			this.Stop();
		}
	}
}
