using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.Debug
{
	public class DebugGuradPassword : MonoBehaviour
	{
		public bool[] Password;

		private List<bool> currPassword = new List<bool>();

		private float pressTime;

		private void Start()
		{
			DebugConsole.AddButton("切换服务", delegate
			{
				string text = DebugConsole.GetText();
				ClientConfig.Instance.ResourcesUrl = text;
				ClientConfig.Instance.Save();
				DebugConsole.Log("succeed!");
			});
			DebugConsole.AddButton("去密码", delegate
			{
				PlayerPrefs.DeleteKey("gDebugGuard");
				PlayerPrefs.Save();
			});
		}

		private void OnDestroy()
		{
			DebugConsole.RemoveButton("切换服务");
			DebugConsole.RemoveButton("去密码");
		}

		public void OnPress(bool isdown)
		{
			if (isdown)
			{
				this.pressTime = Time.time;
			}
			else
			{
				this.currPassword.Add(Time.time - this.pressTime > 0.5f);
			}
		}

		private void Update()
		{
			bool mouseButton = Input.GetMouseButton(2);
			if (mouseButton)
			{
				bool flag = true;
				if (this.Password != null && this.Password.Length == this.currPassword.Count)
				{
					for (int i = 0; i < this.Password.Length; i++)
					{
						if (this.Password[i] != this.currPassword[i])
						{
							flag = false;
							break;
						}
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					PlayerPrefs.SetInt("gDebugGuard", 1);
					PlayerPrefs.Save();
					foreach (DebugGuard current in DebugGuard.DebugGuards)
					{
						if (current != null)
						{
							current.UpdateEnable();
						}
					}
					base.gameObject.SetActive(false);
				}
				this.currPassword.Clear();
			}
		}
	}
}
