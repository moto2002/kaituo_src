using Assets.Tools.Script.Event;
using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Compoment
{
	public class UIRadioBtnGroup : MonoBehaviour
	{
		public UISelectionBtn[] uiSelectionBtns;

		public UISelectionBtn defaultBtn;

		public readonly Signal<UISelectionBtn> onSelecedChangeSignal = new Signal<UISelectionBtn>();

		public readonly Signal<UISelectionBtn> onSelecedAgainSignal = new Signal<UISelectionBtn>();

		public readonly Signal<UISelectionBtn> onInvalidClickSignal = new Signal<UISelectionBtn>();

		public UISelectionBtn currSelectedBtn
		{
			get;
			private set;
		}

		private void Awake()
		{
			this.Init();
		}

		public void Init()
		{
			if (this.uiSelectionBtns.Length == 0)
			{
				return;
			}
			if (this.defaultBtn == null)
			{
				this.defaultBtn = this.uiSelectionBtns[0];
			}
			for (int i = 0; i < this.uiSelectionBtns.Length; i++)
			{
				UISelectionBtn uISelectionBtn = this.uiSelectionBtns[i];
				uISelectionBtn.IsOn = (uISelectionBtn == this.defaultBtn);
			}
			for (int j = 0; j < this.uiSelectionBtns.Length; j++)
			{
				UISelectionBtn uISelectionBtn2 = this.uiSelectionBtns[j];
				uISelectionBtn2.Index = j;
				uISelectionBtn2.onChangeSignal.AddEventListener(new Action<UISelectionBtn>(this.OnSelectionBtnChangeHandler));
				uISelectionBtn2.onInvalidClickSignal.AddEventListener(new Action<UISelectionBtn>(this.OnInvalidClickHandler));
			}
			this.currSelectedBtn = this.defaultBtn;
		}

		public void Reset()
		{
			this.defaultBtn.IsOn = true;
		}

		private void OnSelectionBtnChangeHandler(UISelectionBtn obj)
		{
			if (obj.IsOn)
			{
				if (obj == this.currSelectedBtn)
				{
					return;
				}
				UISelectionBtn currSelectedBtn = this.currSelectedBtn;
				this.currSelectedBtn = obj;
				currSelectedBtn.IsOn = false;
				this.onSelecedChangeSignal.Dispatch(obj);
			}
			else if (obj == this.currSelectedBtn)
			{
				this.onSelecedAgainSignal.Dispatch(obj);
				obj.IsOn = true;
			}
		}

		private void OnInvalidClickHandler(UISelectionBtn obj)
		{
			this.onInvalidClickSignal.Dispatch(obj);
		}
	}
}
