using System;
using UnityEngine;

namespace XQ.Framework.Language
{
	public class LanguageVisible : MonoBehaviour
	{
		public string[] VisibleLanguages;

		private void Awake()
		{
			string langKey = LanguageManager.GetLangKey();
			bool flag = false;
			for (int i = 0; i < this.VisibleLanguages.Length; i++)
			{
				string b = this.VisibleLanguages[i];
				if (langKey == b)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
