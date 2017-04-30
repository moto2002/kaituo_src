using Assets.Tools.Script.Event;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UISelectionBtn : MonoBehaviour
	{
		public GameObject onBtn;

		public GameObject offBtn;

		[HideInInspector]
		public int Index;

		public string ButtonName;

		private bool _btnEnabled = true;

		public readonly Signal<UISelectionBtn> onChangeSignal = new Signal<UISelectionBtn>();

		[HideInInspector]
		public List<EventDelegate> onChange = new List<EventDelegate>();

		public readonly Signal<UISelectionBtn> onInvalidClickSignal = new Signal<UISelectionBtn>();

		private bool _isOn = true;

		public bool BtnEnabled
		{
			get
			{
				return this._btnEnabled;
			}
			set
			{
				this._btnEnabled = value;
			}
		}

		public bool IsOn
		{
			get
			{
				return this._isOn;
			}
			set
			{
				this._isOn = value;
				this.UpdateState();
				EventDelegate.Execute(this.onChange);
				this.onChangeSignal.Dispatch(this);
			}
		}

		public float Value
		{
			get
			{
				return (float)((!this._isOn) ? 0 : 1);
			}
			set
			{
				this.IsOn = (value > 0f);
			}
		}

		private void OnClick()
		{
			if (this.BtnEnabled)
			{
				this.IsOn = !this.IsOn;
			}
			else
			{
				this.onInvalidClickSignal.Dispatch(this);
			}
		}

		private void UpdateState()
		{
			this.onBtn.SetActive(this._isOn);
			this.offBtn.SetActive(!this._isOn);
		}
	}
}
