using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
	public class GameEntryMessageBox : MonoBehaviour
	{
		public UILabel label;

		public GameObject OkBtn;

		private Action endCallback;

		private int UsePassword;

		public void ShowWithPassword(string message, Action onPass)
		{
			this.Show(message);
			this.endCallback = onPass;
			this.UsePassword = 0;
		}

		public void Show(string message)
		{
			this.OkBtn.SetActive(false);
			base.gameObject.SetActive(true);
			this.label.text = string.Format("[b]{0}[-]", message);
			this.UsePassword = -1;
		}

		public void Show(string message, Action onEnd)
		{
			this.OkBtn.SetActive(true);
			base.gameObject.SetActive(true);
			this.label.text = string.Format("[b]{0}[-]", message);
			this.endCallback = onEnd;
			this.UsePassword = -1;
		}

		public void OnOk()
		{
			base.gameObject.SetActive(false);
			if (this.endCallback != null)
			{
				Action action = this.endCallback;
				this.endCallback = null;
				action();
			}
		}

		public void OnClickPassword()
		{
			if (this.UsePassword >= 0)
			{
				base.CancelInvoke("NextPassword");
				base.Invoke("NextPassword", 1f);
				this.UsePassword++;
			}
			if (this.UsePassword == 8)
			{
				base.CancelInvoke("NextPassword");
				base.gameObject.SetActive(false);
				if (this.endCallback != null)
				{
					Action action = this.endCallback;
					this.endCallback = null;
					action();
				}
			}
		}

		private void NextPassword()
		{
			this.UsePassword = 0;
		}
	}
}
