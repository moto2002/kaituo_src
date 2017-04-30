using System;
using System.Collections.Generic;
using UnityEngine;

namespace XQ.Framework.Lua
{
	public struct ManagerResource
	{
		public GameObject bindObject;

		public List<UnityEngine.Object> value;

		public static ManagerResource New(GameObject bind)
		{
			return new ManagerResource
			{
				bindObject = bind,
				value = new List<UnityEngine.Object>()
			};
		}

		public ManagerResource AddValue(UnityEngine.Object obj)
		{
			this.value.Add(obj);
			return this;
		}
	}
}
