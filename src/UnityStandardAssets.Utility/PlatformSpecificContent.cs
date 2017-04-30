using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class PlatformSpecificContent : MonoBehaviour
	{
		private enum BuildTargetGroup
		{
			Standalone,
			Mobile
		}

		[SerializeField]
		private PlatformSpecificContent.BuildTargetGroup m_BuildTargetGroup;

		[SerializeField]
		private GameObject[] m_Content = new GameObject[0];

		[SerializeField]
		private MonoBehaviour[] m_MonoBehaviours = new MonoBehaviour[0];

		[SerializeField]
		private bool m_ChildrenOfThisObject;

		private void OnEnable()
		{
			this.CheckEnableContent();
		}

		private void CheckEnableContent()
		{
			if (this.m_BuildTargetGroup == PlatformSpecificContent.BuildTargetGroup.Mobile)
			{
				this.EnableContent(true);
			}
			else
			{
				this.EnableContent(false);
			}
		}

		private void EnableContent(bool enabled)
		{
			if (this.m_Content.Length > 0)
			{
				GameObject[] content = this.m_Content;
				for (int i = 0; i < content.Length; i++)
				{
					GameObject gameObject = content[i];
					if (gameObject != null)
					{
						gameObject.SetActive(enabled);
					}
				}
			}
			if (this.m_ChildrenOfThisObject)
			{
				foreach (Transform transform in base.transform)
				{
					transform.gameObject.SetActive(enabled);
				}
			}
			if (this.m_MonoBehaviours.Length > 0)
			{
				MonoBehaviour[] monoBehaviours = this.m_MonoBehaviours;
				for (int j = 0; j < monoBehaviours.Length; j++)
				{
					MonoBehaviour monoBehaviour = monoBehaviours[j];
					monoBehaviour.enabled = enabled;
				}
			}
		}
	}
}
