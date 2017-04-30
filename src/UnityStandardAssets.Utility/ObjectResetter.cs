using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ObjectResetter : MonoBehaviour
	{
		private Vector3 originalPosition;

		private Quaternion originalRotation;

		private List<Transform> originalStructure;

		private Rigidbody Rigidbody;

		private void Start()
		{
			this.originalStructure = new List<Transform>(base.GetComponentsInChildren<Transform>());
			this.originalPosition = base.transform.position;
			this.originalRotation = base.transform.rotation;
			this.Rigidbody = base.GetComponent<Rigidbody>();
		}

		public void DelayedReset(float delay)
		{
			base.StartCoroutine(this.ResetCoroutine(delay));
		}

		[DebuggerHidden]
		public IEnumerator ResetCoroutine(float delay)
		{
			ObjectResetter.<ResetCoroutine>c__Iterator7 <ResetCoroutine>c__Iterator = new ObjectResetter.<ResetCoroutine>c__Iterator7();
			<ResetCoroutine>c__Iterator.delay = delay;
			<ResetCoroutine>c__Iterator.<$>delay = delay;
			<ResetCoroutine>c__Iterator.<>f__this = this;
			return <ResetCoroutine>c__Iterator;
		}
	}
}
