using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Core.Compoment
{
	public class SetNGUIObjectActive : MonoBehaviour
	{
		public void SetThisActiveTrue()
		{
			NGUITools.SetActive(base.gameObject, true);
		}

		public void SetThisActiveFalse()
		{
			NGUITools.SetActive(base.gameObject, false);
		}

		public void SetGameObjectActiveTrue(GameObject obj)
		{
			NGUITools.SetActive(obj, true);
		}

		public void SetGameObjectActiveFalse(GameObject obj)
		{
			NGUITools.SetActive(obj, false);
		}
	}
}
