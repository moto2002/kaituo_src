using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace Assets.Tools.EXTools1_0.NGUITool.Toast
{
	public class ToastTip : MonoBehaviour
	{
		private static GameObject tipPrefab;

		private static ToastTip toastTip;

		private static GameObject root;

		public UILabel Label;

		public UITweener ShowTweener;

		public UITweener EndTweener;

		public static void ShowTip(string text)
		{
			if (ToastTip.toastTip == null)
			{
				if (ToastTip.tipPrefab == null)
				{
					ToastTip.root = UIRoot.list[0].gameObject.AddEmptyGameObject();
					ToastTip.root.name = "TipRoot";
					UIPanel uIPanel = ToastTip.root.AddComponent<UIPanel>();
					uIPanel.depth = 2500;
					ToastTip.tipPrefab = Resources.Load<GameObject>("Tool/ToastTip");
				}
				GameObject gameObject = ToastTip.root.AddInstantiate(ToastTip.tipPrefab);
				ToastTip.toastTip = gameObject.GetComponent<ToastTip>();
				ToastTip.toastTip.transform.localPosition = new Vector3(0f, -270f, 0f);
			}
			float num = (text.Length <= 5) ? 0f : ((float)(text.Length - 5) * 0.1f);
			ToastTip.toastTip.Show(text, 1f + num);
		}

		public void Show(string text, float time)
		{
			this.Label.text = text;
			this.ShowTweener.ResetToBeginning();
			this.EndTweener.delay = time;
			this.EndTweener.ResetToBeginning();
			this.ShowTweener.Play();
			this.EndTweener.Play();
		}
	}
}
