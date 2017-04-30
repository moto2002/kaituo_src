using System;
using UnityEngine;

public class FixPerspective2DEffect : MonoBehaviour
{
	private Vector3 pos = Vector3.zero;

	private Transform mainCameraTrans;

	private void Start()
	{
		this.mainCameraTrans = UICamera.mainCamera.transform;
		this.pos = new Vector3(base.transform.position.x, this.mainCameraTrans.position.y, base.transform.position.z);
		this.FixAngle();
	}

	private void LateUpdate()
	{
		Vector3 lhs = new Vector3(base.transform.position.x, this.mainCameraTrans.position.y, base.transform.position.z);
		if (lhs != this.pos)
		{
			this.pos = lhs;
			this.FixAngle();
		}
	}

	private void FixAngle()
	{
		Vector3 from = this.pos - this.mainCameraTrans.position;
		float num = Vector3.Angle(from, this.mainCameraTrans.forward);
		base.transform.localEulerAngles = new Vector3(base.transform.localRotation.x, (from.x <= 0f) ? (-num) : num, base.transform.localRotation.z);
	}
}
