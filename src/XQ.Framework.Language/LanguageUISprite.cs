using Assets.Tools.Script.Helper;
using System;
using UnityEngine;

namespace XQ.Framework.Language
{
	public class LanguageUISprite : MonoBehaviour
	{
		public UISprite Sprite;

		private void Awake()
		{
			string spriteName = this.Sprite.spriteName;
			string[] array = spriteName.Split(new char[]
			{
				'_'
			});
			array[array.Length - 1] = LanguageManager.GetLangKey();
			this.Sprite.spriteName = array.Joint("_");
			this.Sprite.MakePixelPerfect();
		}
	}
}
