using System;

namespace Assets.Script.Mvc.demo.model
{
	public class NumData : Model
	{
		private int num;

		public int Num
		{
			get
			{
				return this.num;
			}
			set
			{
				this.num = value;
				this.EventDispatcher.DispatchEvent<int>("NumChange", this.num);
			}
		}
	}
}
