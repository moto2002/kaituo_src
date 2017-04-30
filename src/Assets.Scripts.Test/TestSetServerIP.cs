using System;
using UnityEngine;

namespace Assets.Scripts.Test
{
	public class TestSetServerIP : MonoBehaviour
	{
		public static string SVR_IP;

		public static int SVR_PORT;

		public bool EditorIpEnable = true;

		[Header("只在编辑器环境下有效")]
		public string IP;

		public int Port;

		public bool RunInBackground;

		private void Start()
		{
		}
	}
}
