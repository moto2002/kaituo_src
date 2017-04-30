using System;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class NGUIToggle : MonoBehaviour
	{
		public GameObject ChooseState;

		public GameObject UnChooseState;

		private bool m_ToggleState;

		public bool ToggleState
		{
			get
			{
				return this.m_ToggleState;
			}
			set
			{
				this.m_ToggleState = value;
				this.ChooseState.SetActive(this.m_ToggleState);
				this.UnChooseState.SetActive(!this.m_ToggleState);
			}
		}
	}
}
