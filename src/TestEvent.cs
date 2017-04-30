using Assets.Tools.Script.Caller;
using Assets.Tools.Script.Event;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
	public Signal<string> OnSignal = new Signal<string>();

	private void Start()
	{
		Debug.Log(base.gameObject.GetComponent("TestEvent"));
		Debug.Log(base.gameObject.GetComponent("UIRoot"));
		DelayCall.Call(delegate
		{
			this.OnSignal.Dispatch("911a");
		}, 2f, false);
		List<int> list = new List<int>();
		list.Sort();
	}
}
