using Assets.Tools.Script.Event;
using System;
using System.Collections.Generic;

namespace Assets.Tools.Script.Popupbox
{
	public class PopList
	{
		public static PopList globalPopList = new PopList();

		private List<IPopBox> _popBoxs = new List<IPopBox>();

		private IPopBox _currPopBox;

		public Signal<IPopBox> onOneClosesSignal
		{
			get;
			private set;
		}

		public SimpleSignal allEndSignal
		{
			get;
			private set;
		}

		public IPopBox currPopBox
		{
			get
			{
				return this._currPopBox;
			}
		}

		public PopList()
		{
			this.onOneClosesSignal = new Signal<IPopBox>();
			this.allEndSignal = new SimpleSignal();
		}

		public void Add(IPopBox popBox)
		{
			this._popBoxs.Add(popBox);
			popBox.SetActive(false);
			this.Show();
		}

		public void AddAt(IPopBox popBox, int index)
		{
			this._popBoxs.Insert(index, popBox);
			popBox.SetActive(false);
			this.Show();
		}

		public void Show()
		{
			if (this._currPopBox != null || this._popBoxs.Count == 0)
			{
				return;
			}
			this.ShowNext();
		}

		public void Clear()
		{
			this._popBoxs.Clear();
		}

		public void Dispose()
		{
		}

		private void OnOneCloseHandler(IPopBox obj)
		{
			this.onOneClosesSignal.Dispatch(obj);
			if (this._popBoxs.Count > 0)
			{
				this.ShowNext();
			}
			else
			{
				this._currPopBox = null;
				this.allEndSignal.Dispatch();
			}
		}

		private void ShowNext()
		{
			this._currPopBox = this._popBoxs[0];
			this._popBoxs.RemoveAt(0);
			if (this._currPopBox != null)
			{
				this._currPopBox.SetActive(true);
				this._currPopBox.Show();
				this._currPopBox.OnCloseSignal.AddEventListener(new Action<IPopBox>(this.OnOneCloseHandler));
			}
			else
			{
				this.OnOneCloseHandler(this._currPopBox);
			}
		}
	}
}
