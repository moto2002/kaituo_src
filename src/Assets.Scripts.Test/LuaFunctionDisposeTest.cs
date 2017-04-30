using LuaInterface;
using System;
using UnityEngine;

namespace Assets.Scripts.Test
{
	public class LuaFunctionDisposeTest : MonoBehaviour
	{
		public LuaFunction Function;

		public void CallTest(LuaFunction f)
		{
			f.Call();
		}

		public void CacheTest(LuaFunction f)
		{
			this.Function = f;
		}

		public void OnDestroy()
		{
		}
	}
}
