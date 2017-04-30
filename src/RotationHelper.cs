using DG.Tweening;
using System;
using UnityEngine;

public class RotationHelper : MonoBehaviour
{
	public float duration;

	public int rotation;

	private void Start()
	{
		base.transform.DORotate(new Vector3((float)this.rotation, 0f, 0f), this.duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
	}
}
