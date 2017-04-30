using Assets.Extends.EXNGUI.Compoment;
using Assets.Scripts.Tools.Event;
using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Framework.Data;
using XQ.Framework.Lua.Utility;

namespace XQ.Framework.Lua
{
	public class LuaMonoBehaviour : ILuaScriptBase
	{
		private List<LuaTable> itemTabls;

		private readonly List<LuaFunction> luaFunctions = new List<LuaFunction>();

		private LoadAssetBundleData assetBundleRef;

		private LuaTableInfo tableInfo;

		private LuaFunction disableFunc;

		private bool needGetDisableFunc = true;

		private LuaFunction enableFunc;

		private bool needGetEnableFunc = true;

		private bool closeIsDestroy;

		private string luaName;

		private string key;

		public LuaTable AddItemTable
		{
			set
			{
				if (this.itemTabls == null)
				{
					this.itemTabls = new List<LuaTable>();
				}
				this.itemTabls.Add(value);
			}
		}

		public override void OnAwake()
		{
		}

		public override void OnDestroyNow()
		{
			if (GameManager.ExitGame)
			{
				return;
			}
			if (this.itemTabls != null)
			{
				this.itemTabls.ForEach(delegate(LuaTable r)
				{
					r.Dispose();
				});
				this.itemTabls.Clear();
			}
			LuaFunction function = GameManager.LuaManager.GetFunction("removeFrameworkTableInstance", true);
			if (null != function)
			{
				function.CallNoRet(new object[]
				{
					this.luaName
				});
			}
			this.ClearEvent();
			if (this.assetBundleRef != null)
			{
				ResourceManager.Dispose(this.luaName, this.key);
				this.assetBundleRef.Dispose();
			}
		}

		protected void OnEnable()
		{
			if (this.tableInfo == null)
			{
				return;
			}
			if (this.needGetEnableFunc)
			{
				this.enableFunc = this.tableInfo.Table.RawGetLuaFunction("OnEnable");
				this.needGetEnableFunc = false;
			}
			if (null != this.enableFunc)
			{
				this.enableFunc.Call();
			}
		}

		public void OnDisable()
		{
			if (GameManager.ExitGame)
			{
				return;
			}
			if (this.closeIsDestroy)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (this.tableInfo != null)
			{
				if (this.needGetDisableFunc)
				{
					this.disableFunc = this.tableInfo.Table.RawGetLuaFunction("OnDisable");
					this.needGetDisableFunc = false;
				}
				if (null != this.disableFunc)
				{
					this.disableFunc.Call();
				}
			}
		}

		public void OnInit(LoadAssetBundleData abRef, bool _closeIsDestroy, string _key, string _luaName)
		{
			this.luaName = _luaName;
			this.key = _key;
			this.assetBundleRef = abRef;
			this.closeIsDestroy = _closeIsDestroy;
			ResourceRef resRef = GameManager.GetResRef(this.luaName, null, true);
			this.tableInfo = resRef.TableInfo[this.key];
			LuaMonoBehaviour.AddEvent(this, this.tableInfo.Table, this.luaFunctions);
		}

		public void ClearEvent()
		{
			if (this.tableInfo != null)
			{
				LuaFunction luaFunction = this.tableInfo.Table.RawGetLuaFunction("Dispose");
				if (null != luaFunction)
				{
					luaFunction.Call();
					luaFunction.Dispose();
				}
			}
			if (null != this.disableFunc)
			{
				this.disableFunc.Dispose();
			}
			if (null != this.enableFunc)
			{
				this.enableFunc.Dispose();
			}
			this.tableInfo = null;
			this.disableFunc = (this.enableFunc = null);
			this.luaFunctions.ForEach(new Action<LuaFunction>(UtilHelper.DestroyLua));
			this.luaFunctions.Clear();
		}

		public static void AddEvent(LuaMonoBehaviour luaMono, LuaTable table, List<LuaFunction> luaFunctions)
		{
			LuaFunction luaFunction = table.RawGetLuaFunction("Element");
			if (null != luaFunction)
			{
				Transform transform = luaMono.transform;
				object[] array = luaFunction.Call(null);
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					string text = array[i] as string;
					string text2 = text;
					int num2 = text.LastIndexOf('/');
					if (num2 != -1)
					{
						text2 = text.Substring(num2 + 1);
					}
					if (text2.StartsWith("gui"))
					{
						LuaMonoBehaviour.AddToEvent(text2, transform.FindChild(text.Substring(0, text.LastIndexOf('_'))).gameObject, table, luaFunctions);
					}
					i++;
				}
				luaFunction.Dispose();
			}
		}

		public static void AddEvent(GameObject eventObject, LuaTable table, string eventSuffix)
		{
			LuaMonoBehaviour.AddToEvent(eventObject.name + eventSuffix, eventObject, table, null);
		}

		private static void AddToEvent(string eventName, GameObject gameObject, LuaTable table, List<LuaFunction> luaFunctions)
		{
			string text = eventName.Substring(eventName.LastIndexOf('_') + 1);
			string text2 = text.Substring(0, 3);
			string text3 = text2;
			switch (text3)
			{
			case "cli":
				LuaMonoBehaviour.AddClick(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "rad":
				LuaMonoBehaviour.AddRadio(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "dra":
				LuaMonoBehaviour.AddDrag(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "dov":
				LuaMonoBehaviour.AddDragOver(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "pre":
				LuaMonoBehaviour.AddPress(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "ada":
				LuaMonoBehaviour.AddAdapter(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			case "fin":
				LuaMonoBehaviour.AddOnFinished(gameObject, table.RawGetLuaFunction(eventName), luaFunctions);
				return;
			}
		}

		private static void AddDrag(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			UIEventListener.Get(obj).onDrag = delegate(GameObject go, Vector2 delta)
			{
				function.CallNoRet(new object[]
				{
					obj,
					delta
				});
			};
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddDragOver(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			UIEventListener.Get(obj).onDragOver = delegate(GameObject o)
			{
				function.CallNoRet(new object[]
				{
					obj
				});
			};
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddPress(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			UIEventListener component = obj.GetComponent<UIEventListener>();
			if (component != null)
			{
				component.onPress = delegate(GameObject go, bool b)
				{
					function.CallNoRet(new object[]
					{
						obj,
						b
					});
				};
			}
			else
			{
				UIPressListener.Get(obj).onPress = delegate(GameObject go, bool b)
				{
					function.CallNoRet(new object[]
					{
						obj,
						b
					});
				};
			}
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddClick(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			UIClickListener.Get(obj).onClick = delegate(GameObject o)
			{
				function.CallNoRet(new object[]
				{
					obj
				});
			};
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddRadio(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			obj.GetComponent<UIRadioBtnGroup>().onSelecedChangeSignal.AddEventListener(delegate(UISelectionBtn btn)
			{
				function.CallNoRet(new object[]
				{
					btn
				});
			});
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddAdapter(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			obj.GetComponent<LuaEventAdapter>().AddListener(function);
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}

		private static void AddOnFinished(GameObject obj, LuaFunction function, List<LuaFunction> luaFunctions)
		{
			if (null == obj)
			{
				return;
			}
			List<EventDelegate> list = null;
			UITweener component = obj.GetComponent<UITweener>();
			if (component)
			{
				list = component.onFinished;
			}
			if (list == null)
			{
				TypewriterEffect component2 = obj.GetComponent<TypewriterEffect>();
				if (component2)
				{
					list = component2.onFinished;
				}
			}
			EventDelegate.Add(list, new EventDelegate.Callback(function.Call));
			if (luaFunctions != null)
			{
				luaFunctions.Add(function);
			}
		}
	}
}
