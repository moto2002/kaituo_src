using System;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[ExecuteInEditMode]
	public class GlobalBlackboard : Blackboard
	{
		public static List<GlobalBlackboard> allGlobals = new List<GlobalBlackboard>();

		public new string name
		{
			get
			{
				return base.name;
			}
			set
			{
				if (base.name != value)
				{
					base.name = value;
					this.CheckUniqueName();
				}
			}
		}

		public static GlobalBlackboard Find(string name)
		{
			return GlobalBlackboard.allGlobals.Find((GlobalBlackboard b) => b.name == name);
		}

		private void OnAwake()
		{
			if (base.enabled && !GlobalBlackboard.allGlobals.Contains(this))
			{
				GlobalBlackboard.allGlobals.Add(this);
			}
		}

		private void OnEnable()
		{
			if (!GlobalBlackboard.allGlobals.Contains(this))
			{
				GlobalBlackboard.allGlobals.Add(this);
			}
			this.CheckUniqueName();
		}

		private void OnDisable()
		{
			GlobalBlackboard.allGlobals.Remove(this);
		}

		private bool CheckUniqueName()
		{
			if (GlobalBlackboard.allGlobals.Find((GlobalBlackboard b) => b.name == this.name && b != this))
			{
				Debug.LogError(string.Format("There is a duplicate <b>GlobalBlackboard</b> named '{0}' in the scene. Please rename it", this.name), this);
				return false;
			}
			return true;
		}
	}
}
