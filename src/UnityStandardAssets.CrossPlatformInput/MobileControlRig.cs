using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		private void Start()
		{
			EventSystem x = UnityEngine.Object.FindObjectOfType<EventSystem>();
			if (x == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		private void EnableControlRig(bool enabled)
		{
			foreach (Transform transform in base.transform)
			{
				transform.gameObject.SetActive(enabled);
			}
		}
	}
}
