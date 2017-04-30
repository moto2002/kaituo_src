using Assets.Tools.Script.Debug;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Tools.Lua
{
	public class LuaReferenceCounter
	{
		private class LuaTableRefProxy : IReferenceCounterHandler
		{
			public string Id;

			public override string ToString()
			{
				return this.Id;
			}

			public void HandleClick()
			{
				if (!Application.isPlaying)
				{
					return;
				}
				if (LuaReferenceCounter.printTabReferenceFunc == null)
				{
					LuaReferenceCounter.printTabReferenceFunc = GameManager.LuaManager.GetTable("ReferenceCounter", true).GetLuaFunction("PrintTabReferenceWithTabId");
				}
				LuaReferenceCounter.printTabReferenceFunc.CallNoRet(new object[]
				{
					this.Id
				});
			}
		}

		private static Dictionary<LuaReferenceCounter.LuaTableRefProxy, string> tables = new Dictionary<LuaReferenceCounter.LuaTableRefProxy, string>();

		private static LuaFunction checkFunc;

		private static LuaFunction printTabReferenceFunc;

		private static List<LuaReferenceCounter.LuaTableRefProxy> destroyTables = new List<LuaReferenceCounter.LuaTableRefProxy>();

		private static int snapshootIndex = 0;

		public static void Mark(string typeName, string table, string tableName)
		{
			LuaReferenceCounter.LuaTableRefProxy luaTableRefProxy = new LuaReferenceCounter.LuaTableRefProxy
			{
				Id = table
			};
			LuaReferenceCounter.tables.Add(luaTableRefProxy, string.Empty);
			ReferenceCounter.Mark(typeName, luaTableRefProxy, tableName);
		}

		public static void GC()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (LuaReferenceCounter.checkFunc == null)
			{
				LuaReferenceCounter.checkFunc = GameManager.LuaManager.GetTable("ReferenceCounter", true).GetLuaFunction("Has");
			}
			LuaReferenceCounter.destroyTables.Clear();
			foreach (LuaReferenceCounter.LuaTableRefProxy current in LuaReferenceCounter.tables.Keys)
			{
				object obj = LuaReferenceCounter.checkFunc.Call(new object[]
				{
					current.Id
				})[0];
				if (!(bool)obj)
				{
					LuaReferenceCounter.destroyTables.Add(current);
				}
			}
			foreach (LuaReferenceCounter.LuaTableRefProxy current2 in LuaReferenceCounter.destroyTables)
			{
				LuaReferenceCounter.tables.Remove(current2);
			}
		}

		public static void MarkAll()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			LuaFunction luaFunction = GameManager.LuaManager.GetTable("ReferenceCounter", true).GetLuaFunction("MarkAll");
			luaFunction.Call();
		}

		public static void Snapshoot()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			LuaFunction luaFunction = GameManager.LuaManager.GetTable("ReferenceCounter", true).GetLuaFunction("Snapshoot");
			luaFunction.Call();
			LuaFunction luaFunction2 = GameManager.LuaManager.GetTable("ReferenceCounter", true).GetLuaFunction("AnalyzeSnapshoot");
			luaFunction2.Call(new object[]
			{
				LuaReferenceCounter.snapshootIndex,
				++LuaReferenceCounter.snapshootIndex
			});
		}
	}
}
