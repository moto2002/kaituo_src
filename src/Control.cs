using Jacovone;
using System;
using UnityEngine;

public class Control : MonoBehaviour
{
	public PathMagicAnimator pma;

	private void Start()
	{
	}

	private void Update()
	{
		this.pma.VelocityBias = Input.GetAxis("Horizontal") / 2f;
	}
}
