using Assets.Tools.Script.Event;
using System;

namespace Assets.Tools.Script.Popupbox
{
	public interface IPopBox
	{
		Signal<IPopBox> OnCloseSignal
		{
			get;
		}

		void Show();

		void SetActive(bool boxActive);
	}
}
