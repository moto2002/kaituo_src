using Assets.Extends.EXTools.Debug.Console;
using Assets.Tools.Script.Editor.Tool;
using Assets.Tools.Script.Helper;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Lua;

namespace Assets.Scripts.Tools.Lua
{
	public class LuaTableDebugAnalyse : IObjectDebugAnalyse
	{
		public int a = 100;

		private Color blue;

		private Color white;

		private Color green;

		private LuaFunction tostringFunction;

		public LuaTableDebugAnalyse()
		{
			this.blue = ColorTool.GetColorFromRGBHexadecimal("4f9cd6");
			this.white = ColorTool.GetColorFromRGBHexadecimal("dcdcdc");
			this.green = ColorTool.GetColorFromRGBHexadecimal("b5cea8");
		}

		public void Show(object obj, string objName, ObjectAnalyseDisplayer displayer)
		{
			if (this.tostringFunction == null)
			{
				this.tostringFunction = GameManager.LuaManager.GetTable("_G", true).GetLuaFunction("tostring");
			}
			LuaTable table = obj as LuaTable;
			List<object> list = new List<object>();
			Dictionary<object, object> luaHashtable = new LuaTableEnumerator(table).ToHashtable();
			foreach (object current in luaHashtable.Keys)
			{
				list.Add(current);
			}
			list.Sort(delegate(object l, object r)
			{
				object obj4 = luaHashtable[l];
				object obj5 = luaHashtable[r];
				string x = (obj4 != null) ? obj4.GetType().Name : "Unknow";
				string text = (obj5 != null) ? obj5.GetType().Name : "Unknow";
				if (x != text)
				{
					return StringComparer.CurrentCulture.Compare(x, text);
				}
				if (l is double && r is double)
				{
					double num = (double)l;
					double num2 = (double)r;
					if (num > num2)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					if (l is double)
					{
						return 1;
					}
					if (r is double)
					{
						return 1;
					}
					return StringComparer.CurrentCulture.Compare(l.ToString(), r.ToString());
				}
			});
			for (int i = 0; i < list.Count; i++)
			{
				object obj2 = list[i];
				if (obj2 is LuaTable)
				{
					this.tostringFunction.Call(new object[]
					{
						obj2
					}).ToString();
				}
				else
				{
					obj2.ToString();
				}
				object obj3 = luaHashtable[obj2];
				string str = string.Format("{0} {1} {2}", ((obj3 != null) ? obj3.GetType().Name : "Unknow").SetColor(this.blue), obj2.ToString().SetColor(this.white), ((obj3 != null) ? obj3.ToString() : "nil").SetColor(this.green));
				if (displayer.GUILayoutBtn(str) && obj3 != null)
				{
					displayer.ShowObjectChild(obj3, string.Format("{0}.{1}", objName, obj2));
				}
			}
		}

		public bool IsActiveBy(object obj)
		{
			return obj is LuaTable;
		}
	}
}
