using System;
using UnityEngine;

namespace Assets.Extends.EXNGUI.Inputtool
{
	public class MutexKeyBinding : MonoBehaviour
	{
		public KeyCode keyCode = KeyCode.Escape;

		[SerializeField]
		private UISprite _buttonSprite;

		public UISprite ButtonSprite
		{
			get
			{
				UISprite uISprite = this._buttonSprite;
				if (uISprite == null)
				{
					uISprite = base.gameObject.GetComponent<UISprite>();
				}
				if (uISprite == null)
				{
					uISprite = base.gameObject.GetComponentInChildren<UISprite>();
				}
				return uISprite;
			}
		}

		private void Start()
		{
			NGUILinkKeyInput.GetOrCreateInstance().AddLink(this);
		}

		private void OnDestroy()
		{
			if (NGUILinkKeyInput.instance != null)
			{
				NGUILinkKeyInput.instance.DeleteLink(this);
			}
		}
	}
}
