using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class SimpleActivatorMenu : MonoBehaviour
	{
		public GUIText camSwitchButton;

		public GameObject[] objects;

		private int m_CurrentActiveObject;

		private void OnEnable()
		{
			this.m_CurrentActiveObject = 0;
			this.camSwitchButton.text = this.objects[this.m_CurrentActiveObject].name;
		}

		public void NextCamera()
		{
			int num = (this.m_CurrentActiveObject + 1 < this.objects.Length) ? (this.m_CurrentActiveObject + 1) : 0;
			for (int i = 0; i < this.objects.Length; i++)
			{
				this.objects[i].SetActive(i == num);
			}
			this.m_CurrentActiveObject = num;
			this.camSwitchButton.text = this.objects[this.m_CurrentActiveObject].name;
		}
	}
}
