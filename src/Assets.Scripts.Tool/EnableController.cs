using System;

namespace Assets.Scripts.Tool
{
	public class EnableController
	{
		private Action<bool> setEnable;

		private int invalidFactor;

		public EnableController(Action<bool> setEnable)
		{
			this.setEnable = setEnable;
		}

		public void AddInvalidFactor()
		{
			this.invalidFactor++;
			this.setEnable(false);
		}

		public void RemoveInvalidFactor()
		{
			if (this.invalidFactor > 0)
			{
				this.invalidFactor--;
			}
			if (this.invalidFactor == 0)
			{
				this.setEnable(true);
			}
		}

		public void AddInvalidFactor(object requester)
		{
			this.AddInvalidFactor();
		}

		public void RemoveInvalidFactor(object requester)
		{
			this.RemoveInvalidFactor();
		}

		public void ClearInvalidFactor()
		{
			this.invalidFactor = 0;
			this.setEnable(true);
		}
	}
}
