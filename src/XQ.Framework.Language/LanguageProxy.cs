using System;
using UnityEngine;

namespace XQ.Framework.Language
{
	public class LanguageProxy : MonoBehaviour
	{
		public string langKey;

		protected void Awake()
		{
			if (LanguageManager.IsChsLanguage(null))
			{
				return;
			}
			UILabel component = base.GetComponent<UILabel>();
			component.text = LanguageManager.GetLangText(this.langKey);
		}
	}
}
