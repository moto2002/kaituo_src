using System;

namespace Assets.Extends.EXNGUI.Core.Input.Mouse
{
	public class MouseEvent : EventDelegateFunction
	{
		private bool inIt;

		private bool down;

		public override string EventDelegateName()
		{
			return "on click";
		}

		private void OnMouseEnter()
		{
			this.inIt = true;
		}

		private void OnMouseExit()
		{
			this.inIt = false;
		}

		private void OnMouseDown()
		{
			this.inIt = true;
			this.down = true;
		}

		private void OnMouseUp()
		{
			if (this.down && this.inIt)
			{
				this.OnClick();
			}
		}

		private void OnClick()
		{
			EventDelegate.Execute(this.EventDelegates);
		}
	}
}
