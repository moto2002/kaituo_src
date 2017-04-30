using System;
using UnityEngine;

public class VelociraptorController : MonoBehaviour
{
	private Transform thisTransform;

	private Animator anim;

	private Vector3 lastPos;

	private void Start()
	{
		this.thisTransform = base.transform;
		this.anim = base.GetComponent<Animator>();
		this.lastPos = this.thisTransform.position;
	}

	private void Update()
	{
		float num = 1f / Time.deltaTime * (this.lastPos - this.thisTransform.position).magnitude;
		this.anim.SetFloat("Velocity", num);
		Debug.Log(num);
		this.lastPos = this.thisTransform.position;
	}
}
