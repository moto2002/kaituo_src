using Assets.Script.Mvc;
using Assets.Script.Mvc.demo.controller;
using Assets.Script.Mvc.demo.model;
using Assets.Script.Mvc.demo.view;
using System;
using UnityEngine;

namespace Assets.Tools.Script.Mvc.demo
{
	public class TestStart : MonoBehaviour
	{
		public NumView NumView;

		private MvcContext mvcContext;

		private void Start()
		{
			this.mvcContext = new MvcContext();
			this.mvcContext.RegisterModel<NumData>(new NumData());
			this.mvcContext.RegisterView<NumView>(this.NumView);
			this.mvcContext.RegisterCommand("AddNum", new AddNumCommand());
		}
	}
}
