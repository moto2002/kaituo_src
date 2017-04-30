using Assets.Script.Mvc.demo.model;
using System;

namespace Assets.Script.Mvc.demo.controller
{
	public class AddNumCommand : Command
	{
		private NumData numData;

		public override void OnRegister()
		{
			this.numData = this.Context.GetModel<NumData>();
		}

		public override void Execute(IEvent e)
		{
			int data = (e as Event<int>).Data;
			this.numData.Num += data;
		}
	}
}
