using Assets.Tools.Script.Debug;
using System;
using UnityEngine;

namespace Assets.Scripts.Test
{
	public class TestServiceView : MonoBehaviour
	{
		public static TestServiceView Instance;

		private void Awake()
		{
			TestService testService = new TestService();
		}

		private void Start()
		{
		}

		private void TextRun()
		{
			RunningTimeLog.TickTime("get by name");
			for (int i = 0; i < 10000; i++)
			{
				Component component = base.GetComponent("TestServiceView");
			}
			RunningTimeLog.LogDistanceTickTime("get by name");
			RunningTimeLog.TickTime("get by type");
			for (int j = 0; j < 10000; j++)
			{
				TestServiceView component2 = base.GetComponent<TestServiceView>();
			}
			RunningTimeLog.LogDistanceTickTime("get by type");
		}
	}
}
