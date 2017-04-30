using DG.Tweening;
using SWS;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class RapidInputDemo : MonoBehaviour
{
	public TextMesh speedDisplay;

	public TextMesh timeDisplay;

	public float topSpeed = 15f;

	public float addSpeed = 2f;

	public float delay = 0.05f;

	public float slowTime = 0.5f;

	public float minPitch;

	public float maxPitch = 2f;

	private splineMove move;

	private float currentSpeed;

	private float timeCounter;

	private void Start()
	{
		this.move = base.GetComponent<splineMove>();
		if (!this.move)
		{
			Debug.LogWarning(base.gameObject.name + " missing movement script!");
			return;
		}
		this.move.speed = 0.01f;
		this.move.StartMove();
		this.move.Pause(0f);
		this.move.speed = 0f;
	}

	private void Update()
	{
		if (this.move.tween == null || !this.move.tween.IsActive() || this.move.tween.IsComplete())
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (!this.move.tween.IsPlaying())
			{
				this.move.Resume();
			}
			float num = this.currentSpeed + this.addSpeed;
			if (num >= this.topSpeed)
			{
				num = this.topSpeed;
			}
			this.move.ChangeSpeed(num);
			base.StopAllCoroutines();
			base.StartCoroutine("SlowDown");
		}
		this.speedDisplay.text = "YOUR SPEED: " + Mathf.Round(this.move.speed * 100f) / 100f;
		this.timeCounter += Time.deltaTime;
		this.timeDisplay.text = "YOUR TIME: " + Mathf.Round(this.timeCounter * 100f) / 100f;
	}

	[DebuggerHidden]
	private IEnumerator SlowDown()
	{
		RapidInputDemo.<SlowDown>c__Iterator24 <SlowDown>c__Iterator = new RapidInputDemo.<SlowDown>c__Iterator24();
		<SlowDown>c__Iterator.<>f__this = this;
		return <SlowDown>c__Iterator;
	}
}
