using DG.Tweening;
using SWS;
using System;
using UnityEngine;

public class PathInputDemo : MonoBehaviour
{
	public float speedMultiplier = 10f;

	public float progress;

	private splineMove move;

	private Animator animator;

	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
		this.move = base.GetComponent<splineMove>();
		this.move.StartMove();
		this.move.Pause(0f);
		this.progress = 0f;
	}

	private void Update()
	{
		float num = this.speedMultiplier / 100f;
		float num2 = this.move.tween.Duration(true);
		if (Input.GetKey("right"))
		{
			this.progress += Time.deltaTime * 10f * num;
			this.progress = Mathf.Clamp(this.progress, 0f, num2);
			this.move.tween.fullPosition = this.progress;
		}
		if (Input.GetKey("left"))
		{
			this.progress -= Time.deltaTime * 10f * num;
			this.progress = Mathf.Clamp(this.progress, 0f, num2);
			this.move.tween.fullPosition = this.progress;
		}
		if ((Input.GetKey("right") || Input.GetKey("left")) && this.progress != 0f && this.progress != num2)
		{
			this.animator.SetFloat("Speed", this.move.speed);
		}
		else
		{
			this.animator.SetFloat("Speed", 0f);
		}
	}

	private void LateUpdate()
	{
		if (Input.GetKey("left"))
		{
			Vector3 localEulerAngles = base.transform.localEulerAngles;
			localEulerAngles.y += 180f;
			base.transform.localEulerAngles = localEulerAngles;
		}
	}
}
