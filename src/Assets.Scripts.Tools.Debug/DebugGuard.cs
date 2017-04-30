using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.Debug
{
	public class DebugGuard : MonoBehaviour
	{
		public enum GuradType
		{
			Always,
			UsePassword,
			NeverUse
		}

		public static List<DebugGuard> DebugGuards = new List<DebugGuard>();

		public DebugGuard.GuradType Type;

		public GameObject Target;

		private void Awake()
		{
			this.UpdateEnable();
		}

		private void Start()
		{
			DebugGuard.DebugGuards.Add(this);
		}

		private void OnDestroy()
		{
			DebugGuard.DebugGuards.Remove(this);
		}

		public void UpdateEnable()
		{
			if (this.Type == DebugGuard.GuradType.Always)
			{
				this.Target.SetActive(true);
			}
			else if (this.Type == DebugGuard.GuradType.UsePassword)
			{
				this.Target.SetActive(PlayerPrefs.HasKey("gDebugGuard"));
			}
			else if (this.Type == DebugGuard.GuradType.NeverUse)
			{
				this.Target.SetActive(false);
			}
		}
	}
}
