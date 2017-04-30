using Assets.Scripts;
using Assets.Tools.Script.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Migration.Scripts.Anim
{
	public class Bind2dHpBar : MonoBehaviour
	{
		private static GameObject prefab;

		private static Dictionary<RpgCharacter, Bind2dHpBar> hpBars = new Dictionary<RpgCharacter, Bind2dHpBar>();

		public GameObject Target;

		public UISprite HpSprite;

		public UISprite DamageSprite;

		public Vector2 Offset = Vector2.zero;

		private int fullWidth;

		private RpgCharacter rpgCharacter;

		public static GameObject Prefab
		{
			get
			{
				if (Bind2dHpBar.prefab == null)
				{
				}
				return Bind2dHpBar.prefab;
			}
		}

		public static Bind2dHpBar Create(RpgCharacter character, GameObject targetPoint, float size)
		{
			Bind2dHpBar component;
			if (!Bind2dHpBar.hpBars.TryGetValue(character, out component))
			{
				if (targetPoint == null)
				{
					targetPoint = character.gameObject;
				}
				GameObject gameObject = UIRoot.list[0].gameObject.AddInstantiate(Bind2dHpBar.Prefab);
				component = gameObject.GetComponent<Bind2dHpBar>();
				component.transform.localScale = Vector3.one * size;
				component.rpgCharacter = character;
				component.Target = targetPoint;
				component.fullWidth = component.HpSprite.width;
				component.Show();
				Bind2dHpBar.hpBars.Add(character, component);
			}
			return component;
		}

		public static void Destroy(RpgCharacter character)
		{
			Bind2dHpBar bind2dHpBar;
			bool flag = Bind2dHpBar.hpBars.TryGetValue(character, out bind2dHpBar);
			if (flag)
			{
				UnityEngine.Object.Destroy(bind2dHpBar.gameObject);
				Bind2dHpBar.hpBars.Remove(character);
			}
		}

		public void Show()
		{
		}

		public void HpTo(int toHp)
		{
		}

		public void HpTo(int toHp, float time, bool ignoreTimeScale, Action onEnd)
		{
		}

		private bool Check()
		{
			return true;
		}
	}
}
