using Assets.Extends.EXNGUI.Compoment;
using Assets.Scripts.Game;
using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DelegateFactory
{
	private class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Predicate_int_Event : LuaDelegate
	{
		public System_Predicate_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_int_Event : LuaDelegate
	{
		public System_Comparison_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(int param0, int param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(int param0, int param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UnityEngine_Camera_CameraCallback_Event : LuaDelegate
	{
		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Application_LogCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LogCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Application_LogCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Application_AdvertisingIdentifierCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, bool param1, string param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, bool param1, string param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_AudioClip_PCMReaderCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(float[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(float[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_AudioClip_PCMSetPositionCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_GetKeyStateFunc_Event : LuaDelegate
	{
		public UICamera_GetKeyStateFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetKeyStateFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(KeyCode param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(KeyCode param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetAxisFunc_Event : LuaDelegate
	{
		public UICamera_GetAxisFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetAxisFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public float Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public float CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetAnyKeyFunc_Event : LuaDelegate
	{
		public UICamera_GetAnyKeyFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetAnyKeyFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetMouseDelegate_Event : LuaDelegate
	{
		public UICamera_GetMouseDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetMouseDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public UICamera.MouseOrTouch Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			UICamera.MouseOrTouch result = (UICamera.MouseOrTouch)this.func.CheckObject(typeof(UICamera.MouseOrTouch));
			this.func.EndPCall();
			return result;
		}

		public UICamera.MouseOrTouch CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			UICamera.MouseOrTouch result = (UICamera.MouseOrTouch)this.func.CheckObject(typeof(UICamera.MouseOrTouch));
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetTouchDelegate_Event : LuaDelegate
	{
		public UICamera_GetTouchDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetTouchDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public UICamera.MouseOrTouch Call(int param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			UICamera.MouseOrTouch result = (UICamera.MouseOrTouch)this.func.CheckObject(typeof(UICamera.MouseOrTouch));
			this.func.EndPCall();
			return result;
		}

		public UICamera.MouseOrTouch CallWithSelf(int param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			UICamera.MouseOrTouch result = (UICamera.MouseOrTouch)this.func.CheckObject(typeof(UICamera.MouseOrTouch));
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_RemoveTouchDelegate_Event : LuaDelegate
	{
		public UICamera_RemoveTouchDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_RemoveTouchDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_OnScreenResize_Event : LuaDelegate
	{
		public UICamera_OnScreenResize_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_OnScreenResize_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_OnCustomInput_Event : LuaDelegate
	{
		public UICamera_OnCustomInput_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_OnCustomInput_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_OnSchemeChange_Event : LuaDelegate
	{
		public UICamera_OnSchemeChange_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_OnSchemeChange_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_VoidDelegate_Event : LuaDelegate
	{
		public UICamera_VoidDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_VoidDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_BoolDelegate_Event : LuaDelegate
	{
		public UICamera_BoolDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_BoolDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_FloatDelegate_Event : LuaDelegate
	{
		public UICamera_FloatDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_FloatDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_VectorDelegate_Event : LuaDelegate
	{
		public UICamera_VectorDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_VectorDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_ObjectDelegate_Event : LuaDelegate
	{
		public UICamera_ObjectDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_ObjectDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_KeyCodeDelegate_Event : LuaDelegate
	{
		public UICamera_KeyCodeDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_KeyCodeDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_MoveDelegate_Event : LuaDelegate
	{
		public UICamera_MoveDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_MoveDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_GetTouchCountCallback_Event : LuaDelegate
	{
		public UICamera_GetTouchCountCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetTouchCountCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetTouchCallback_Event : LuaDelegate
	{
		public UICamera_GetTouchCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetTouchCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public UICamera.Touch Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			UICamera.Touch result = (UICamera.Touch)this.func.CheckObject(typeof(UICamera.Touch));
			this.func.EndPCall();
			return result;
		}

		public UICamera.Touch CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			UICamera.Touch result = (UICamera.Touch)this.func.CheckObject(typeof(UICamera.Touch));
			this.func.EndPCall();
			return result;
		}
	}

	private class EventDelegate_Callback_Event : LuaDelegate
	{
		public EventDelegate_Callback_Event(LuaFunction func) : base(func)
		{
		}

		public EventDelegate_Callback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_VoidDelegate_Event : LuaDelegate
	{
		public UIEventListener_VoidDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_VoidDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_BoolDelegate_Event : LuaDelegate
	{
		public UIEventListener_BoolDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_BoolDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_FloatDelegate_Event : LuaDelegate
	{
		public UIEventListener_FloatDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_FloatDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_VectorDelegate_Event : LuaDelegate
	{
		public UIEventListener_VectorDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_VectorDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_ObjectDelegate_Event : LuaDelegate
	{
		public UIEventListener_ObjectDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_ObjectDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_KeyCodeDelegate_Event : LuaDelegate
	{
		public UIEventListener_KeyCodeDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_KeyCodeDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIPanel_OnGeometryUpdated_Event : LuaDelegate
	{
		public UIPanel_OnGeometryUpdated_Event(LuaFunction func) : base(func)
		{
		}

		public UIPanel_OnGeometryUpdated_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIPanel_OnClippingMoved_Event : LuaDelegate
	{
		public UIPanel_OnClippingMoved_Event(LuaFunction func) : base(func)
		{
		}

		public UIPanel_OnClippingMoved_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIPanel param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIPanel param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UILabel_ModifierFunc_Event : LuaDelegate
	{
		public UILabel_ModifierFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UILabel_ModifierFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public string Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			string result = this.func.CheckString();
			this.func.EndPCall();
			return result;
		}

		public string CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			string result = this.func.CheckString();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIWidget_OnDrawCallChange_Event : LuaDelegate
	{
		public UIWidget_OnDrawCallChange_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_OnDrawCallChange_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIDrawCall param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIDrawCall param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_OnDimensionsChanged_Event : LuaDelegate
	{
		public UIWidget_OnDimensionsChanged_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_OnDimensionsChanged_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_OnPostFillCallback_Event : LuaDelegate
	{
		public UIWidget_OnPostFillCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_OnPostFillCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color> param4)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PushObject(param2);
			this.func.PushObject(param3);
			this.func.PushObject(param4);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color> param4)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PushObject(param2);
			this.func.PushObject(param3);
			this.func.PushObject(param4);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIDrawCall_OnRenderCallback_Event : LuaDelegate
	{
		public UIDrawCall_OnRenderCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UIDrawCall_OnRenderCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Material param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Material param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_HitCheck_Event : LuaDelegate
	{
		public UIWidget_HitCheck_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_HitCheck_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIGrid_OnReposition_Event : LuaDelegate
	{
		public UIGrid_OnReposition_Event(LuaFunction func) : base(func)
		{
		}

		public UIGrid_OnReposition_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_UnityEngine_Transform_Event : LuaDelegate
	{
		public System_Comparison_UnityEngine_Transform_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_UnityEngine_Transform_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(Transform param0, Transform param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(Transform param0, Transform param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UITable_OnReposition_Event : LuaDelegate
	{
		public UITable_OnReposition_Event(LuaFunction func) : base(func)
		{
		}

		public UITable_OnReposition_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class SpringPanel_OnFinished_Event : LuaDelegate
	{
		public SpringPanel_OnFinished_Event(LuaFunction func) : base(func)
		{
		}

		public SpringPanel_OnFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICenterOnChild_OnCenterCallback_Event : LuaDelegate
	{
		public UICenterOnChild_OnCenterCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UICenterOnChild_OnCenterCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event : LuaDelegate
	{
		public Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event(LuaFunction func) : base(func)
		{
		}

		public Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Transform Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Transform result = (Transform)this.func.CheckObject(typeof(Transform));
			this.func.EndPCall();
			return result;
		}

		public Transform CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Transform result = (Transform)this.func.CheckObject(typeof(Transform));
			this.func.EndPCall();
			return result;
		}
	}

	private class UIWrapContent_OnInitializeItem_Event : LuaDelegate
	{
		public UIWrapContent_OnInitializeItem_Event(LuaFunction func) : base(func)
		{
		}

		public UIWrapContent_OnInitializeItem_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, int param1, int param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, int param1, int param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_Transform_Event : LuaDelegate
	{
		public System_Action_UnityEngine_Transform_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_Transform_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIToggle_Validate_Event : LuaDelegate
	{
		public UIToggle_Validate_Event(LuaFunction func) : base(func)
		{
		}

		public UIToggle_Validate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIScrollView_OnDragNotification_Event : LuaDelegate
	{
		public UIScrollView_OnDragNotification_Event(LuaFunction func) : base(func)
		{
		}

		public UIScrollView_OnDragNotification_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIInput_OnValidate_Event : LuaDelegate
	{
		public UIInput_OnValidate_Event(LuaFunction func) : base(func)
		{
		}

		public UIInput_OnValidate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public char Call(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public char CallWithSelf(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UISectorWrapContent_OnWrapItem_Event : LuaDelegate
	{
		public UISectorWrapContent_OnWrapItem_Event(LuaFunction func) : base(func)
		{
		}

		public UISectorWrapContent_OnWrapItem_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UISectorWrapContent_SwitchToCenterPanel_Event : LuaDelegate
	{
		public UISectorWrapContent_SwitchToCenterPanel_Event(LuaFunction func) : base(func)
		{
		}

		public UISectorWrapContent_SwitchToCenterPanel_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIPopupMenu_OnPopupItemClick_Event : LuaDelegate
	{
		public UIPopupMenu_OnPopupItemClick_Event(LuaFunction func) : base(func)
		{
		}

		public UIPopupMenu_OnPopupItemClick_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class SDK_CALLBACK_Event : LuaDelegate
	{
		public SDK_CALLBACK_Event(LuaFunction func) : base(func)
		{
		}

		public SDK_CALLBACK_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(object[] param0)
		{
			this.func.BeginPCall();
			for (int i = 0; i < param0.Length; i++)
			{
				this.func.Push(param0[i]);
			}
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(object[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			for (int i = 0; i < param0.Length; i++)
			{
				this.func.Push(param0[i]);
			}
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event : LuaDelegate
	{
		public System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UISelectionBtn param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UISelectionBtn param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Func_UnityEngine_Transform_bool_Event : LuaDelegate
	{
		public System_Func_UnityEngine_Transform_bool_Event(LuaFunction func) : base(func)
		{
		}

		public System_Func_UnityEngine_Transform_bool_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(Transform param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event : LuaDelegate
	{
		public System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIClip param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIClip param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Action_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1, GameObject param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1, GameObject param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public GameObject Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			GameObject result = (GameObject)this.func.CheckObject(typeof(GameObject));
			this.func.EndPCall();
			return result;
		}

		public GameObject CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			GameObject result = (GameObject)this.func.CheckObject(typeof(GameObject));
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Func_UnityEngine_GameObject_bool_Event : LuaDelegate
	{
		public System_Func_UnityEngine_GameObject_bool_Event(LuaFunction func) : base(func)
		{
		}

		public System_Func_UnityEngine_GameObject_bool_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Predicate_UIRoot_Event : LuaDelegate
	{
		public System_Predicate_UIRoot_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_UIRoot_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(UIRoot param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(UIRoot param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_UIRoot_Event : LuaDelegate
	{
		public System_Action_UIRoot_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UIRoot_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIRoot param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIRoot param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_UIRoot_Event : LuaDelegate
	{
		public System_Comparison_UIRoot_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_UIRoot_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(UIRoot param0, UIRoot param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(UIRoot param0, UIRoot param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Predicate_EventDelegate_Event : LuaDelegate
	{
		public System_Predicate_EventDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_EventDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(EventDelegate param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(EventDelegate param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_EventDelegate_Event : LuaDelegate
	{
		public System_Action_EventDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_EventDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(EventDelegate param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(EventDelegate param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_EventDelegate_Event : LuaDelegate
	{
		public System_Comparison_EventDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_EventDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(EventDelegate param0, EventDelegate param1)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(EventDelegate param0, EventDelegate param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class SpringPosition_OnFinished_Event : LuaDelegate
	{
		public SpringPosition_OnFinished_Event(LuaFunction func) : base(func)
		{
		}

		public SpringPosition_OnFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event : LuaDelegate
	{
		public System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(IGameEntryTask param0, float param1, string param2)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.Push((double)param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(IGameEntryTask param0, float param1, string param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.Push((double)param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_Vector2_Event : LuaDelegate
	{
		public System_Action_UnityEngine_Vector2_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_Vector2_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIProgressBar_OnDragFinished_Event : LuaDelegate
	{
		public UIProgressBar_OnDragFinished_Event(LuaFunction func) : base(func)
		{
		}

		public UIProgressBar_OnDragFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event : LuaDelegate
	{
		public System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event(LuaFunction func) : base(func)
		{
		}

		public System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Vector3 Call(Transform param0, int param1, Vector3 param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			Vector3 result = this.func.CheckVector3();
			this.func.EndPCall();
			return result;
		}

		public Vector3 CallWithSelf(Transform param0, int param1, Vector3 param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			Vector3 result = this.func.CheckVector3();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIDrawCall_OnRenderQueueChange_Event : LuaDelegate
	{
		public UIDrawCall_OnRenderQueueChange_Event(LuaFunction func) : base(func)
		{
		}

		public UIDrawCall_OnRenderQueueChange_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_string_Event : LuaDelegate
	{
		public System_Action_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_bool_Event : LuaDelegate
	{
		public System_Action_bool_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_bool_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Predicate_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Predicate_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Comparison_UnityEngine_GameObject_Event : LuaDelegate
	{
		public System_Comparison_UnityEngine_GameObject_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_UnityEngine_GameObject_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Predicate_string_Event : LuaDelegate
	{
		public System_Predicate_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Comparison_string_Event : LuaDelegate
	{
		public System_Comparison_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(string param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(string param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Predicate_object_Event : LuaDelegate
	{
		public System_Predicate_object_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_object_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(object param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(object param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_object_Event : LuaDelegate
	{
		public System_Action_object_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_object_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(object param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(object param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_object_Event : LuaDelegate
	{
		public System_Comparison_object_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_object_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(object param0, object param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(object param0, object param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class BetterList_UICamera_CompareFunc_Event : LuaDelegate
	{
		public BetterList_UICamera_CompareFunc_Event(LuaFunction func) : base(func)
		{
		}

		public BetterList_UICamera_CompareFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(UICamera param0, UICamera param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(UICamera param0, UICamera param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	public delegate Delegate DelegateValue(LuaFunction func, LuaTable self, bool flag);

	public static Dictionary<Type, DelegateFactory.DelegateValue> dict;

	static DelegateFactory()
	{
		DelegateFactory.dict = new Dictionary<Type, DelegateFactory.DelegateValue>();
		DelegateFactory.Register();
	}

	[NoToLua]
	public static void Register()
	{
		DelegateFactory.dict.Clear();
		DelegateFactory.dict.Add(typeof(Action), new DelegateFactory.DelegateValue(DelegateFactory.System_Action));
		DelegateFactory.dict.Add(typeof(UnityAction), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Events_UnityAction));
		DelegateFactory.dict.Add(typeof(Predicate<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_int));
		DelegateFactory.dict.Add(typeof(Action<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_int));
		DelegateFactory.dict.Add(typeof(Comparison<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_int));
		DelegateFactory.dict.Add(typeof(Camera.CameraCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Camera_CameraCallback));
		DelegateFactory.dict.Add(typeof(Application.LogCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Application_LogCallback));
		DelegateFactory.dict.Add(typeof(Application.AdvertisingIdentifierCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback));
		DelegateFactory.dict.Add(typeof(AudioClip.PCMReaderCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback));
		DelegateFactory.dict.Add(typeof(AudioClip.PCMSetPositionCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback));
		DelegateFactory.dict.Add(typeof(UICamera.GetKeyStateFunc), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetKeyStateFunc));
		DelegateFactory.dict.Add(typeof(UICamera.GetAxisFunc), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetAxisFunc));
		DelegateFactory.dict.Add(typeof(UICamera.GetAnyKeyFunc), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetAnyKeyFunc));
		DelegateFactory.dict.Add(typeof(UICamera.GetMouseDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetMouseDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.GetTouchDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetTouchDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.RemoveTouchDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_RemoveTouchDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.OnScreenResize), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnScreenResize));
		DelegateFactory.dict.Add(typeof(UICamera.OnCustomInput), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnCustomInput));
		DelegateFactory.dict.Add(typeof(UICamera.OnSchemeChange), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnSchemeChange));
		DelegateFactory.dict.Add(typeof(UICamera.VoidDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_VoidDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.BoolDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_BoolDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.FloatDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_FloatDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.VectorDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_VectorDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.ObjectDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_ObjectDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.KeyCodeDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_KeyCodeDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.MoveDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_MoveDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.GetTouchCountCallback), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetTouchCountCallback));
		DelegateFactory.dict.Add(typeof(UICamera.GetTouchCallback), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetTouchCallback));
		DelegateFactory.dict.Add(typeof(EventDelegate.Callback), new DelegateFactory.DelegateValue(DelegateFactory.EventDelegate_Callback));
		DelegateFactory.dict.Add(typeof(UIEventListener.VoidDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VoidDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.BoolDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_BoolDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.FloatDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_FloatDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.VectorDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VectorDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.ObjectDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_ObjectDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.KeyCodeDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_KeyCodeDelegate));
		DelegateFactory.dict.Add(typeof(UIPanel.OnGeometryUpdated), new DelegateFactory.DelegateValue(DelegateFactory.UIPanel_OnGeometryUpdated));
		DelegateFactory.dict.Add(typeof(UIPanel.OnClippingMoved), new DelegateFactory.DelegateValue(DelegateFactory.UIPanel_OnClippingMoved));
		DelegateFactory.dict.Add(typeof(UILabel.ModifierFunc), new DelegateFactory.DelegateValue(DelegateFactory.UILabel_ModifierFunc));
		DelegateFactory.dict.Add(typeof(UIWidget.OnDrawCallChange), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnDrawCallChange));
		DelegateFactory.dict.Add(typeof(UIWidget.OnDimensionsChanged), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnDimensionsChanged));
		DelegateFactory.dict.Add(typeof(UIWidget.OnPostFillCallback), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnPostFillCallback));
		DelegateFactory.dict.Add(typeof(UIDrawCall.OnRenderCallback), new DelegateFactory.DelegateValue(DelegateFactory.UIDrawCall_OnRenderCallback));
		DelegateFactory.dict.Add(typeof(UIWidget.HitCheck), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_HitCheck));
		DelegateFactory.dict.Add(typeof(UIGrid.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UIGrid_OnReposition));
		DelegateFactory.dict.Add(typeof(Comparison<Transform>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_UnityEngine_Transform));
		DelegateFactory.dict.Add(typeof(UITable.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UITable_OnReposition));
		DelegateFactory.dict.Add(typeof(SpringPanel.OnFinished), new DelegateFactory.DelegateValue(DelegateFactory.SpringPanel_OnFinished));
		DelegateFactory.dict.Add(typeof(UICenterOnChild.OnCenterCallback), new DelegateFactory.DelegateValue(DelegateFactory.UICenterOnChild_OnCenterCallback));
		DelegateFactory.dict.Add(typeof(UICenterOnChildV2.OnDragFinishedCenter), new DelegateFactory.DelegateValue(DelegateFactory.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter));
		DelegateFactory.dict.Add(typeof(UIWrapContent.OnInitializeItem), new DelegateFactory.DelegateValue(DelegateFactory.UIWrapContent_OnInitializeItem));
		DelegateFactory.dict.Add(typeof(Action<Transform>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_Transform));
		DelegateFactory.dict.Add(typeof(UIToggle.Validate), new DelegateFactory.DelegateValue(DelegateFactory.UIToggle_Validate));
		DelegateFactory.dict.Add(typeof(UIScrollView.OnDragNotification), new DelegateFactory.DelegateValue(DelegateFactory.UIScrollView_OnDragNotification));
		DelegateFactory.dict.Add(typeof(UIInput.OnValidate), new DelegateFactory.DelegateValue(DelegateFactory.UIInput_OnValidate));
		DelegateFactory.dict.Add(typeof(UISectorWrapContent.OnWrapItem), new DelegateFactory.DelegateValue(DelegateFactory.UISectorWrapContent_OnWrapItem));
		DelegateFactory.dict.Add(typeof(UISectorWrapContent.SwitchToCenterPanel), new DelegateFactory.DelegateValue(DelegateFactory.UISectorWrapContent_SwitchToCenterPanel));
		DelegateFactory.dict.Add(typeof(UIPopupMenu.OnPopupItemClick), new DelegateFactory.DelegateValue(DelegateFactory.UIPopupMenu_OnPopupItemClick));
		DelegateFactory.dict.Add(typeof(SDK_CALLBACK), new DelegateFactory.DelegateValue(DelegateFactory.SDK_CALLBACK));
		DelegateFactory.dict.Add(typeof(Action<UISelectionBtn>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn));
		DelegateFactory.dict.Add(typeof(Func<Transform, bool>), new DelegateFactory.DelegateValue(DelegateFactory.System_Func_UnityEngine_Transform_bool));
		DelegateFactory.dict.Add(typeof(Action<UIClip>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip));
		DelegateFactory.dict.Add(typeof(Action<GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Action<GameObject, GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Action<GameObject, GameObject, GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Func<GameObject, GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Func_UnityEngine_GameObject_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Func<GameObject, bool>), new DelegateFactory.DelegateValue(DelegateFactory.System_Func_UnityEngine_GameObject_bool));
		DelegateFactory.dict.Add(typeof(Predicate<UIRoot>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_UIRoot));
		DelegateFactory.dict.Add(typeof(Action<UIRoot>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UIRoot));
		DelegateFactory.dict.Add(typeof(Comparison<UIRoot>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_UIRoot));
		DelegateFactory.dict.Add(typeof(Predicate<EventDelegate>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_EventDelegate));
		DelegateFactory.dict.Add(typeof(Action<EventDelegate>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_EventDelegate));
		DelegateFactory.dict.Add(typeof(Comparison<EventDelegate>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_EventDelegate));
		DelegateFactory.dict.Add(typeof(SpringPosition.OnFinished), new DelegateFactory.DelegateValue(DelegateFactory.SpringPosition_OnFinished));
		DelegateFactory.dict.Add(typeof(Action<IGameEntryTask, float, string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string));
		DelegateFactory.dict.Add(typeof(Action<Vector2>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_Vector2));
		DelegateFactory.dict.Add(typeof(UIProgressBar.OnDragFinished), new DelegateFactory.DelegateValue(DelegateFactory.UIProgressBar_OnDragFinished));
		DelegateFactory.dict.Add(typeof(Func<Transform, int, Vector3, Vector3>), new DelegateFactory.DelegateValue(DelegateFactory.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3));
		DelegateFactory.dict.Add(typeof(UIDrawCall.OnRenderQueueChange), new DelegateFactory.DelegateValue(DelegateFactory.UIDrawCall_OnRenderQueueChange));
		DelegateFactory.dict.Add(typeof(Action<string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_string));
		DelegateFactory.dict.Add(typeof(Action<bool>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_bool));
		DelegateFactory.dict.Add(typeof(Predicate<GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Comparison<GameObject>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_UnityEngine_GameObject));
		DelegateFactory.dict.Add(typeof(Predicate<string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_string));
		DelegateFactory.dict.Add(typeof(Comparison<string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_string));
		DelegateFactory.dict.Add(typeof(Predicate<object>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_object));
		DelegateFactory.dict.Add(typeof(Action<object>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_object));
		DelegateFactory.dict.Add(typeof(Comparison<object>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_object));
		DelegateFactory.dict.Add(typeof(BetterList<UICamera>.CompareFunc), new DelegateFactory.DelegateValue(DelegateFactory.BetterList_UICamera_CompareFunc));
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func = null)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, null, false);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, null, false);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func);
		return @delegate;
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func, LuaTable self)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, self, true);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func, self);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, self, true);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func, self);
		return @delegate;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
	{
		LuaState luaState = func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate = invocationList[i].Target as LuaDelegate;
			if (luaDelegate != null && luaDelegate.func == func)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate.func);
				break;
			}
		}
		return obj;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, Delegate dg)
	{
		LuaDelegate luaDelegate = dg.Target as LuaDelegate;
		if (luaDelegate == null)
		{
			obj = Delegate.Remove(obj, dg);
			return obj;
		}
		LuaState luaState = luaDelegate.func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate2 = invocationList[i].Target as LuaDelegate;
			if (luaDelegate2 != null && luaDelegate2 == luaDelegate)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate2.func);
				luaState.DelayDispose(luaDelegate2.self);
				break;
			}
		}
		return obj;
	}

	public static Delegate System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Event system_Action_Event = new DelegateFactory.System_Action_Event(func);
			Action action = new Action(system_Action_Event.Call);
			system_Action_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Event system_Action_Event2 = new DelegateFactory.System_Action_Event(func, self);
		Action action2 = new Action(system_Action_Event2.CallWithSelf);
		system_Action_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UnityAction(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func);
			UnityAction unityAction = new UnityAction(unityEngine_Events_UnityAction_Event.Call);
			unityEngine_Events_UnityAction_Event.method = unityAction.Method;
			return unityAction;
		}
		DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event2 = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func, self);
		UnityAction unityAction2 = new UnityAction(unityEngine_Events_UnityAction_Event2.CallWithSelf);
		unityEngine_Events_UnityAction_Event2.method = unityAction2.Method;
		return unityAction2;
	}

	public static Delegate System_Predicate_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<int>((int param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_int_Event system_Predicate_int_Event = new DelegateFactory.System_Predicate_int_Event(func);
			Predicate<int> predicate = new Predicate<int>(system_Predicate_int_Event.Call);
			system_Predicate_int_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_int_Event system_Predicate_int_Event2 = new DelegateFactory.System_Predicate_int_Event(func, self);
		Predicate<int> predicate2 = new Predicate<int>(system_Predicate_int_Event2.CallWithSelf);
		system_Predicate_int_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<int>(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_int_Event system_Action_int_Event = new DelegateFactory.System_Action_int_Event(func);
			Action<int> action = new Action<int>(system_Action_int_Event.Call);
			system_Action_int_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_int_Event system_Action_int_Event2 = new DelegateFactory.System_Action_int_Event(func, self);
		Action<int> action2 = new Action<int>(system_Action_int_Event2.CallWithSelf);
		system_Action_int_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<int>((int param0, int param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_int_Event system_Comparison_int_Event = new DelegateFactory.System_Comparison_int_Event(func);
			Comparison<int> comparison = new Comparison<int>(system_Comparison_int_Event.Call);
			system_Comparison_int_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_int_Event system_Comparison_int_Event2 = new DelegateFactory.System_Comparison_int_Event(func, self);
		Comparison<int> comparison2 = new Comparison<int>(system_Comparison_int_Event2.CallWithSelf);
		system_Comparison_int_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate UnityEngine_Camera_CameraCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Camera.CameraCallback(delegate(Camera param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func);
			Camera.CameraCallback cameraCallback = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event.Call);
			unityEngine_Camera_CameraCallback_Event.method = cameraCallback.Method;
			return cameraCallback;
		}
		DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event2 = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func, self);
		Camera.CameraCallback cameraCallback2 = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event2.CallWithSelf);
		unityEngine_Camera_CameraCallback_Event2.method = cameraCallback2.Method;
		return cameraCallback2;
	}

	public static Delegate UnityEngine_Application_LogCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Application.LogCallback(delegate(string param0, string param1, LogType param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func);
			Application.LogCallback logCallback = new Application.LogCallback(unityEngine_Application_LogCallback_Event.Call);
			unityEngine_Application_LogCallback_Event.method = logCallback.Method;
			return logCallback;
		}
		DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event2 = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func, self);
		Application.LogCallback logCallback2 = new Application.LogCallback(unityEngine_Application_LogCallback_Event2.CallWithSelf);
		unityEngine_Application_LogCallback_Event2.method = logCallback2.Method;
		return logCallback2;
	}

	public static Delegate UnityEngine_Application_AdvertisingIdentifierCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Application.AdvertisingIdentifierCallback(delegate(string param0, bool param1, string param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event unityEngine_Application_AdvertisingIdentifierCallback_Event = new DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event(func);
			Application.AdvertisingIdentifierCallback advertisingIdentifierCallback = new Application.AdvertisingIdentifierCallback(unityEngine_Application_AdvertisingIdentifierCallback_Event.Call);
			unityEngine_Application_AdvertisingIdentifierCallback_Event.method = advertisingIdentifierCallback.Method;
			return advertisingIdentifierCallback;
		}
		DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event unityEngine_Application_AdvertisingIdentifierCallback_Event2 = new DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event(func, self);
		Application.AdvertisingIdentifierCallback advertisingIdentifierCallback2 = new Application.AdvertisingIdentifierCallback(unityEngine_Application_AdvertisingIdentifierCallback_Event2.CallWithSelf);
		unityEngine_Application_AdvertisingIdentifierCallback_Event2.method = advertisingIdentifierCallback2.Method;
		return advertisingIdentifierCallback2;
	}

	public static Delegate UnityEngine_AudioClip_PCMReaderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new AudioClip.PCMReaderCallback(delegate(float[] param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event unityEngine_AudioClip_PCMReaderCallback_Event = new DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event(func);
			AudioClip.PCMReaderCallback pCMReaderCallback = new AudioClip.PCMReaderCallback(unityEngine_AudioClip_PCMReaderCallback_Event.Call);
			unityEngine_AudioClip_PCMReaderCallback_Event.method = pCMReaderCallback.Method;
			return pCMReaderCallback;
		}
		DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event unityEngine_AudioClip_PCMReaderCallback_Event2 = new DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event(func, self);
		AudioClip.PCMReaderCallback pCMReaderCallback2 = new AudioClip.PCMReaderCallback(unityEngine_AudioClip_PCMReaderCallback_Event2.CallWithSelf);
		unityEngine_AudioClip_PCMReaderCallback_Event2.method = pCMReaderCallback2.Method;
		return pCMReaderCallback2;
	}

	public static Delegate UnityEngine_AudioClip_PCMSetPositionCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new AudioClip.PCMSetPositionCallback(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event unityEngine_AudioClip_PCMSetPositionCallback_Event = new DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event(func);
			AudioClip.PCMSetPositionCallback pCMSetPositionCallback = new AudioClip.PCMSetPositionCallback(unityEngine_AudioClip_PCMSetPositionCallback_Event.Call);
			unityEngine_AudioClip_PCMSetPositionCallback_Event.method = pCMSetPositionCallback.Method;
			return pCMSetPositionCallback;
		}
		DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event unityEngine_AudioClip_PCMSetPositionCallback_Event2 = new DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event(func, self);
		AudioClip.PCMSetPositionCallback pCMSetPositionCallback2 = new AudioClip.PCMSetPositionCallback(unityEngine_AudioClip_PCMSetPositionCallback_Event2.CallWithSelf);
		unityEngine_AudioClip_PCMSetPositionCallback_Event2.method = pCMSetPositionCallback2.Method;
		return pCMSetPositionCallback2;
	}

	public static Delegate UICamera_GetKeyStateFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetKeyStateFunc((KeyCode param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetKeyStateFunc_Event uICamera_GetKeyStateFunc_Event = new DelegateFactory.UICamera_GetKeyStateFunc_Event(func);
			UICamera.GetKeyStateFunc getKeyStateFunc = new UICamera.GetKeyStateFunc(uICamera_GetKeyStateFunc_Event.Call);
			uICamera_GetKeyStateFunc_Event.method = getKeyStateFunc.Method;
			return getKeyStateFunc;
		}
		DelegateFactory.UICamera_GetKeyStateFunc_Event uICamera_GetKeyStateFunc_Event2 = new DelegateFactory.UICamera_GetKeyStateFunc_Event(func, self);
		UICamera.GetKeyStateFunc getKeyStateFunc2 = new UICamera.GetKeyStateFunc(uICamera_GetKeyStateFunc_Event2.CallWithSelf);
		uICamera_GetKeyStateFunc_Event2.method = getKeyStateFunc2.Method;
		return getKeyStateFunc2;
	}

	public static Delegate UICamera_GetAxisFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetAxisFunc((string param0) => 0f);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetAxisFunc_Event uICamera_GetAxisFunc_Event = new DelegateFactory.UICamera_GetAxisFunc_Event(func);
			UICamera.GetAxisFunc getAxisFunc = new UICamera.GetAxisFunc(uICamera_GetAxisFunc_Event.Call);
			uICamera_GetAxisFunc_Event.method = getAxisFunc.Method;
			return getAxisFunc;
		}
		DelegateFactory.UICamera_GetAxisFunc_Event uICamera_GetAxisFunc_Event2 = new DelegateFactory.UICamera_GetAxisFunc_Event(func, self);
		UICamera.GetAxisFunc getAxisFunc2 = new UICamera.GetAxisFunc(uICamera_GetAxisFunc_Event2.CallWithSelf);
		uICamera_GetAxisFunc_Event2.method = getAxisFunc2.Method;
		return getAxisFunc2;
	}

	public static Delegate UICamera_GetAnyKeyFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetAnyKeyFunc(() => false);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetAnyKeyFunc_Event uICamera_GetAnyKeyFunc_Event = new DelegateFactory.UICamera_GetAnyKeyFunc_Event(func);
			UICamera.GetAnyKeyFunc getAnyKeyFunc = new UICamera.GetAnyKeyFunc(uICamera_GetAnyKeyFunc_Event.Call);
			uICamera_GetAnyKeyFunc_Event.method = getAnyKeyFunc.Method;
			return getAnyKeyFunc;
		}
		DelegateFactory.UICamera_GetAnyKeyFunc_Event uICamera_GetAnyKeyFunc_Event2 = new DelegateFactory.UICamera_GetAnyKeyFunc_Event(func, self);
		UICamera.GetAnyKeyFunc getAnyKeyFunc2 = new UICamera.GetAnyKeyFunc(uICamera_GetAnyKeyFunc_Event2.CallWithSelf);
		uICamera_GetAnyKeyFunc_Event2.method = getAnyKeyFunc2.Method;
		return getAnyKeyFunc2;
	}

	public static Delegate UICamera_GetMouseDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetMouseDelegate((int param0) => null);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetMouseDelegate_Event uICamera_GetMouseDelegate_Event = new DelegateFactory.UICamera_GetMouseDelegate_Event(func);
			UICamera.GetMouseDelegate getMouseDelegate = new UICamera.GetMouseDelegate(uICamera_GetMouseDelegate_Event.Call);
			uICamera_GetMouseDelegate_Event.method = getMouseDelegate.Method;
			return getMouseDelegate;
		}
		DelegateFactory.UICamera_GetMouseDelegate_Event uICamera_GetMouseDelegate_Event2 = new DelegateFactory.UICamera_GetMouseDelegate_Event(func, self);
		UICamera.GetMouseDelegate getMouseDelegate2 = new UICamera.GetMouseDelegate(uICamera_GetMouseDelegate_Event2.CallWithSelf);
		uICamera_GetMouseDelegate_Event2.method = getMouseDelegate2.Method;
		return getMouseDelegate2;
	}

	public static Delegate UICamera_GetTouchDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetTouchDelegate((int param0, bool param1) => null);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetTouchDelegate_Event uICamera_GetTouchDelegate_Event = new DelegateFactory.UICamera_GetTouchDelegate_Event(func);
			UICamera.GetTouchDelegate getTouchDelegate = new UICamera.GetTouchDelegate(uICamera_GetTouchDelegate_Event.Call);
			uICamera_GetTouchDelegate_Event.method = getTouchDelegate.Method;
			return getTouchDelegate;
		}
		DelegateFactory.UICamera_GetTouchDelegate_Event uICamera_GetTouchDelegate_Event2 = new DelegateFactory.UICamera_GetTouchDelegate_Event(func, self);
		UICamera.GetTouchDelegate getTouchDelegate2 = new UICamera.GetTouchDelegate(uICamera_GetTouchDelegate_Event2.CallWithSelf);
		uICamera_GetTouchDelegate_Event2.method = getTouchDelegate2.Method;
		return getTouchDelegate2;
	}

	public static Delegate UICamera_RemoveTouchDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.RemoveTouchDelegate(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_RemoveTouchDelegate_Event uICamera_RemoveTouchDelegate_Event = new DelegateFactory.UICamera_RemoveTouchDelegate_Event(func);
			UICamera.RemoveTouchDelegate removeTouchDelegate = new UICamera.RemoveTouchDelegate(uICamera_RemoveTouchDelegate_Event.Call);
			uICamera_RemoveTouchDelegate_Event.method = removeTouchDelegate.Method;
			return removeTouchDelegate;
		}
		DelegateFactory.UICamera_RemoveTouchDelegate_Event uICamera_RemoveTouchDelegate_Event2 = new DelegateFactory.UICamera_RemoveTouchDelegate_Event(func, self);
		UICamera.RemoveTouchDelegate removeTouchDelegate2 = new UICamera.RemoveTouchDelegate(uICamera_RemoveTouchDelegate_Event2.CallWithSelf);
		uICamera_RemoveTouchDelegate_Event2.method = removeTouchDelegate2.Method;
		return removeTouchDelegate2;
	}

	public static Delegate UICamera_OnScreenResize(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.OnScreenResize(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_OnScreenResize_Event uICamera_OnScreenResize_Event = new DelegateFactory.UICamera_OnScreenResize_Event(func);
			UICamera.OnScreenResize onScreenResize = new UICamera.OnScreenResize(uICamera_OnScreenResize_Event.Call);
			uICamera_OnScreenResize_Event.method = onScreenResize.Method;
			return onScreenResize;
		}
		DelegateFactory.UICamera_OnScreenResize_Event uICamera_OnScreenResize_Event2 = new DelegateFactory.UICamera_OnScreenResize_Event(func, self);
		UICamera.OnScreenResize onScreenResize2 = new UICamera.OnScreenResize(uICamera_OnScreenResize_Event2.CallWithSelf);
		uICamera_OnScreenResize_Event2.method = onScreenResize2.Method;
		return onScreenResize2;
	}

	public static Delegate UICamera_OnCustomInput(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.OnCustomInput(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_OnCustomInput_Event uICamera_OnCustomInput_Event = new DelegateFactory.UICamera_OnCustomInput_Event(func);
			UICamera.OnCustomInput onCustomInput = new UICamera.OnCustomInput(uICamera_OnCustomInput_Event.Call);
			uICamera_OnCustomInput_Event.method = onCustomInput.Method;
			return onCustomInput;
		}
		DelegateFactory.UICamera_OnCustomInput_Event uICamera_OnCustomInput_Event2 = new DelegateFactory.UICamera_OnCustomInput_Event(func, self);
		UICamera.OnCustomInput onCustomInput2 = new UICamera.OnCustomInput(uICamera_OnCustomInput_Event2.CallWithSelf);
		uICamera_OnCustomInput_Event2.method = onCustomInput2.Method;
		return onCustomInput2;
	}

	public static Delegate UICamera_OnSchemeChange(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.OnSchemeChange(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_OnSchemeChange_Event uICamera_OnSchemeChange_Event = new DelegateFactory.UICamera_OnSchemeChange_Event(func);
			UICamera.OnSchemeChange onSchemeChange = new UICamera.OnSchemeChange(uICamera_OnSchemeChange_Event.Call);
			uICamera_OnSchemeChange_Event.method = onSchemeChange.Method;
			return onSchemeChange;
		}
		DelegateFactory.UICamera_OnSchemeChange_Event uICamera_OnSchemeChange_Event2 = new DelegateFactory.UICamera_OnSchemeChange_Event(func, self);
		UICamera.OnSchemeChange onSchemeChange2 = new UICamera.OnSchemeChange(uICamera_OnSchemeChange_Event2.CallWithSelf);
		uICamera_OnSchemeChange_Event2.method = onSchemeChange2.Method;
		return onSchemeChange2;
	}

	public static Delegate UICamera_VoidDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.VoidDelegate(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_VoidDelegate_Event uICamera_VoidDelegate_Event = new DelegateFactory.UICamera_VoidDelegate_Event(func);
			UICamera.VoidDelegate voidDelegate = new UICamera.VoidDelegate(uICamera_VoidDelegate_Event.Call);
			uICamera_VoidDelegate_Event.method = voidDelegate.Method;
			return voidDelegate;
		}
		DelegateFactory.UICamera_VoidDelegate_Event uICamera_VoidDelegate_Event2 = new DelegateFactory.UICamera_VoidDelegate_Event(func, self);
		UICamera.VoidDelegate voidDelegate2 = new UICamera.VoidDelegate(uICamera_VoidDelegate_Event2.CallWithSelf);
		uICamera_VoidDelegate_Event2.method = voidDelegate2.Method;
		return voidDelegate2;
	}

	public static Delegate UICamera_BoolDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.BoolDelegate(delegate(GameObject param0, bool param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_BoolDelegate_Event uICamera_BoolDelegate_Event = new DelegateFactory.UICamera_BoolDelegate_Event(func);
			UICamera.BoolDelegate boolDelegate = new UICamera.BoolDelegate(uICamera_BoolDelegate_Event.Call);
			uICamera_BoolDelegate_Event.method = boolDelegate.Method;
			return boolDelegate;
		}
		DelegateFactory.UICamera_BoolDelegate_Event uICamera_BoolDelegate_Event2 = new DelegateFactory.UICamera_BoolDelegate_Event(func, self);
		UICamera.BoolDelegate boolDelegate2 = new UICamera.BoolDelegate(uICamera_BoolDelegate_Event2.CallWithSelf);
		uICamera_BoolDelegate_Event2.method = boolDelegate2.Method;
		return boolDelegate2;
	}

	public static Delegate UICamera_FloatDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.FloatDelegate(delegate(GameObject param0, float param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_FloatDelegate_Event uICamera_FloatDelegate_Event = new DelegateFactory.UICamera_FloatDelegate_Event(func);
			UICamera.FloatDelegate floatDelegate = new UICamera.FloatDelegate(uICamera_FloatDelegate_Event.Call);
			uICamera_FloatDelegate_Event.method = floatDelegate.Method;
			return floatDelegate;
		}
		DelegateFactory.UICamera_FloatDelegate_Event uICamera_FloatDelegate_Event2 = new DelegateFactory.UICamera_FloatDelegate_Event(func, self);
		UICamera.FloatDelegate floatDelegate2 = new UICamera.FloatDelegate(uICamera_FloatDelegate_Event2.CallWithSelf);
		uICamera_FloatDelegate_Event2.method = floatDelegate2.Method;
		return floatDelegate2;
	}

	public static Delegate UICamera_VectorDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.VectorDelegate(delegate(GameObject param0, Vector2 param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_VectorDelegate_Event uICamera_VectorDelegate_Event = new DelegateFactory.UICamera_VectorDelegate_Event(func);
			UICamera.VectorDelegate vectorDelegate = new UICamera.VectorDelegate(uICamera_VectorDelegate_Event.Call);
			uICamera_VectorDelegate_Event.method = vectorDelegate.Method;
			return vectorDelegate;
		}
		DelegateFactory.UICamera_VectorDelegate_Event uICamera_VectorDelegate_Event2 = new DelegateFactory.UICamera_VectorDelegate_Event(func, self);
		UICamera.VectorDelegate vectorDelegate2 = new UICamera.VectorDelegate(uICamera_VectorDelegate_Event2.CallWithSelf);
		uICamera_VectorDelegate_Event2.method = vectorDelegate2.Method;
		return vectorDelegate2;
	}

	public static Delegate UICamera_ObjectDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.ObjectDelegate(delegate(GameObject param0, GameObject param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_ObjectDelegate_Event uICamera_ObjectDelegate_Event = new DelegateFactory.UICamera_ObjectDelegate_Event(func);
			UICamera.ObjectDelegate objectDelegate = new UICamera.ObjectDelegate(uICamera_ObjectDelegate_Event.Call);
			uICamera_ObjectDelegate_Event.method = objectDelegate.Method;
			return objectDelegate;
		}
		DelegateFactory.UICamera_ObjectDelegate_Event uICamera_ObjectDelegate_Event2 = new DelegateFactory.UICamera_ObjectDelegate_Event(func, self);
		UICamera.ObjectDelegate objectDelegate2 = new UICamera.ObjectDelegate(uICamera_ObjectDelegate_Event2.CallWithSelf);
		uICamera_ObjectDelegate_Event2.method = objectDelegate2.Method;
		return objectDelegate2;
	}

	public static Delegate UICamera_KeyCodeDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.KeyCodeDelegate(delegate(GameObject param0, KeyCode param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_KeyCodeDelegate_Event uICamera_KeyCodeDelegate_Event = new DelegateFactory.UICamera_KeyCodeDelegate_Event(func);
			UICamera.KeyCodeDelegate keyCodeDelegate = new UICamera.KeyCodeDelegate(uICamera_KeyCodeDelegate_Event.Call);
			uICamera_KeyCodeDelegate_Event.method = keyCodeDelegate.Method;
			return keyCodeDelegate;
		}
		DelegateFactory.UICamera_KeyCodeDelegate_Event uICamera_KeyCodeDelegate_Event2 = new DelegateFactory.UICamera_KeyCodeDelegate_Event(func, self);
		UICamera.KeyCodeDelegate keyCodeDelegate2 = new UICamera.KeyCodeDelegate(uICamera_KeyCodeDelegate_Event2.CallWithSelf);
		uICamera_KeyCodeDelegate_Event2.method = keyCodeDelegate2.Method;
		return keyCodeDelegate2;
	}

	public static Delegate UICamera_MoveDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.MoveDelegate(delegate(Vector2 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_MoveDelegate_Event uICamera_MoveDelegate_Event = new DelegateFactory.UICamera_MoveDelegate_Event(func);
			UICamera.MoveDelegate moveDelegate = new UICamera.MoveDelegate(uICamera_MoveDelegate_Event.Call);
			uICamera_MoveDelegate_Event.method = moveDelegate.Method;
			return moveDelegate;
		}
		DelegateFactory.UICamera_MoveDelegate_Event uICamera_MoveDelegate_Event2 = new DelegateFactory.UICamera_MoveDelegate_Event(func, self);
		UICamera.MoveDelegate moveDelegate2 = new UICamera.MoveDelegate(uICamera_MoveDelegate_Event2.CallWithSelf);
		uICamera_MoveDelegate_Event2.method = moveDelegate2.Method;
		return moveDelegate2;
	}

	public static Delegate UICamera_GetTouchCountCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetTouchCountCallback(() => 0);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetTouchCountCallback_Event uICamera_GetTouchCountCallback_Event = new DelegateFactory.UICamera_GetTouchCountCallback_Event(func);
			UICamera.GetTouchCountCallback getTouchCountCallback = new UICamera.GetTouchCountCallback(uICamera_GetTouchCountCallback_Event.Call);
			uICamera_GetTouchCountCallback_Event.method = getTouchCountCallback.Method;
			return getTouchCountCallback;
		}
		DelegateFactory.UICamera_GetTouchCountCallback_Event uICamera_GetTouchCountCallback_Event2 = new DelegateFactory.UICamera_GetTouchCountCallback_Event(func, self);
		UICamera.GetTouchCountCallback getTouchCountCallback2 = new UICamera.GetTouchCountCallback(uICamera_GetTouchCountCallback_Event2.CallWithSelf);
		uICamera_GetTouchCountCallback_Event2.method = getTouchCountCallback2.Method;
		return getTouchCountCallback2;
	}

	public static Delegate UICamera_GetTouchCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetTouchCallback((int param0) => null);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetTouchCallback_Event uICamera_GetTouchCallback_Event = new DelegateFactory.UICamera_GetTouchCallback_Event(func);
			UICamera.GetTouchCallback getTouchCallback = new UICamera.GetTouchCallback(uICamera_GetTouchCallback_Event.Call);
			uICamera_GetTouchCallback_Event.method = getTouchCallback.Method;
			return getTouchCallback;
		}
		DelegateFactory.UICamera_GetTouchCallback_Event uICamera_GetTouchCallback_Event2 = new DelegateFactory.UICamera_GetTouchCallback_Event(func, self);
		UICamera.GetTouchCallback getTouchCallback2 = new UICamera.GetTouchCallback(uICamera_GetTouchCallback_Event2.CallWithSelf);
		uICamera_GetTouchCallback_Event2.method = getTouchCallback2.Method;
		return getTouchCallback2;
	}

	public static Delegate EventDelegate_Callback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new EventDelegate.Callback(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.EventDelegate_Callback_Event eventDelegate_Callback_Event = new DelegateFactory.EventDelegate_Callback_Event(func);
			EventDelegate.Callback callback = new EventDelegate.Callback(eventDelegate_Callback_Event.Call);
			eventDelegate_Callback_Event.method = callback.Method;
			return callback;
		}
		DelegateFactory.EventDelegate_Callback_Event eventDelegate_Callback_Event2 = new DelegateFactory.EventDelegate_Callback_Event(func, self);
		EventDelegate.Callback callback2 = new EventDelegate.Callback(eventDelegate_Callback_Event2.CallWithSelf);
		eventDelegate_Callback_Event2.method = callback2.Method;
		return callback2;
	}

	public static Delegate UIEventListener_VoidDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.VoidDelegate(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_VoidDelegate_Event uIEventListener_VoidDelegate_Event = new DelegateFactory.UIEventListener_VoidDelegate_Event(func);
			UIEventListener.VoidDelegate voidDelegate = new UIEventListener.VoidDelegate(uIEventListener_VoidDelegate_Event.Call);
			uIEventListener_VoidDelegate_Event.method = voidDelegate.Method;
			return voidDelegate;
		}
		DelegateFactory.UIEventListener_VoidDelegate_Event uIEventListener_VoidDelegate_Event2 = new DelegateFactory.UIEventListener_VoidDelegate_Event(func, self);
		UIEventListener.VoidDelegate voidDelegate2 = new UIEventListener.VoidDelegate(uIEventListener_VoidDelegate_Event2.CallWithSelf);
		uIEventListener_VoidDelegate_Event2.method = voidDelegate2.Method;
		return voidDelegate2;
	}

	public static Delegate UIEventListener_BoolDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.BoolDelegate(delegate(GameObject param0, bool param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_BoolDelegate_Event uIEventListener_BoolDelegate_Event = new DelegateFactory.UIEventListener_BoolDelegate_Event(func);
			UIEventListener.BoolDelegate boolDelegate = new UIEventListener.BoolDelegate(uIEventListener_BoolDelegate_Event.Call);
			uIEventListener_BoolDelegate_Event.method = boolDelegate.Method;
			return boolDelegate;
		}
		DelegateFactory.UIEventListener_BoolDelegate_Event uIEventListener_BoolDelegate_Event2 = new DelegateFactory.UIEventListener_BoolDelegate_Event(func, self);
		UIEventListener.BoolDelegate boolDelegate2 = new UIEventListener.BoolDelegate(uIEventListener_BoolDelegate_Event2.CallWithSelf);
		uIEventListener_BoolDelegate_Event2.method = boolDelegate2.Method;
		return boolDelegate2;
	}

	public static Delegate UIEventListener_FloatDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.FloatDelegate(delegate(GameObject param0, float param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_FloatDelegate_Event uIEventListener_FloatDelegate_Event = new DelegateFactory.UIEventListener_FloatDelegate_Event(func);
			UIEventListener.FloatDelegate floatDelegate = new UIEventListener.FloatDelegate(uIEventListener_FloatDelegate_Event.Call);
			uIEventListener_FloatDelegate_Event.method = floatDelegate.Method;
			return floatDelegate;
		}
		DelegateFactory.UIEventListener_FloatDelegate_Event uIEventListener_FloatDelegate_Event2 = new DelegateFactory.UIEventListener_FloatDelegate_Event(func, self);
		UIEventListener.FloatDelegate floatDelegate2 = new UIEventListener.FloatDelegate(uIEventListener_FloatDelegate_Event2.CallWithSelf);
		uIEventListener_FloatDelegate_Event2.method = floatDelegate2.Method;
		return floatDelegate2;
	}

	public static Delegate UIEventListener_VectorDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.VectorDelegate(delegate(GameObject param0, Vector2 param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_VectorDelegate_Event uIEventListener_VectorDelegate_Event = new DelegateFactory.UIEventListener_VectorDelegate_Event(func);
			UIEventListener.VectorDelegate vectorDelegate = new UIEventListener.VectorDelegate(uIEventListener_VectorDelegate_Event.Call);
			uIEventListener_VectorDelegate_Event.method = vectorDelegate.Method;
			return vectorDelegate;
		}
		DelegateFactory.UIEventListener_VectorDelegate_Event uIEventListener_VectorDelegate_Event2 = new DelegateFactory.UIEventListener_VectorDelegate_Event(func, self);
		UIEventListener.VectorDelegate vectorDelegate2 = new UIEventListener.VectorDelegate(uIEventListener_VectorDelegate_Event2.CallWithSelf);
		uIEventListener_VectorDelegate_Event2.method = vectorDelegate2.Method;
		return vectorDelegate2;
	}

	public static Delegate UIEventListener_ObjectDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.ObjectDelegate(delegate(GameObject param0, GameObject param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_ObjectDelegate_Event uIEventListener_ObjectDelegate_Event = new DelegateFactory.UIEventListener_ObjectDelegate_Event(func);
			UIEventListener.ObjectDelegate objectDelegate = new UIEventListener.ObjectDelegate(uIEventListener_ObjectDelegate_Event.Call);
			uIEventListener_ObjectDelegate_Event.method = objectDelegate.Method;
			return objectDelegate;
		}
		DelegateFactory.UIEventListener_ObjectDelegate_Event uIEventListener_ObjectDelegate_Event2 = new DelegateFactory.UIEventListener_ObjectDelegate_Event(func, self);
		UIEventListener.ObjectDelegate objectDelegate2 = new UIEventListener.ObjectDelegate(uIEventListener_ObjectDelegate_Event2.CallWithSelf);
		uIEventListener_ObjectDelegate_Event2.method = objectDelegate2.Method;
		return objectDelegate2;
	}

	public static Delegate UIEventListener_KeyCodeDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.KeyCodeDelegate(delegate(GameObject param0, KeyCode param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_KeyCodeDelegate_Event uIEventListener_KeyCodeDelegate_Event = new DelegateFactory.UIEventListener_KeyCodeDelegate_Event(func);
			UIEventListener.KeyCodeDelegate keyCodeDelegate = new UIEventListener.KeyCodeDelegate(uIEventListener_KeyCodeDelegate_Event.Call);
			uIEventListener_KeyCodeDelegate_Event.method = keyCodeDelegate.Method;
			return keyCodeDelegate;
		}
		DelegateFactory.UIEventListener_KeyCodeDelegate_Event uIEventListener_KeyCodeDelegate_Event2 = new DelegateFactory.UIEventListener_KeyCodeDelegate_Event(func, self);
		UIEventListener.KeyCodeDelegate keyCodeDelegate2 = new UIEventListener.KeyCodeDelegate(uIEventListener_KeyCodeDelegate_Event2.CallWithSelf);
		uIEventListener_KeyCodeDelegate_Event2.method = keyCodeDelegate2.Method;
		return keyCodeDelegate2;
	}

	public static Delegate UIPanel_OnGeometryUpdated(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPanel.OnGeometryUpdated(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPanel_OnGeometryUpdated_Event uIPanel_OnGeometryUpdated_Event = new DelegateFactory.UIPanel_OnGeometryUpdated_Event(func);
			UIPanel.OnGeometryUpdated onGeometryUpdated = new UIPanel.OnGeometryUpdated(uIPanel_OnGeometryUpdated_Event.Call);
			uIPanel_OnGeometryUpdated_Event.method = onGeometryUpdated.Method;
			return onGeometryUpdated;
		}
		DelegateFactory.UIPanel_OnGeometryUpdated_Event uIPanel_OnGeometryUpdated_Event2 = new DelegateFactory.UIPanel_OnGeometryUpdated_Event(func, self);
		UIPanel.OnGeometryUpdated onGeometryUpdated2 = new UIPanel.OnGeometryUpdated(uIPanel_OnGeometryUpdated_Event2.CallWithSelf);
		uIPanel_OnGeometryUpdated_Event2.method = onGeometryUpdated2.Method;
		return onGeometryUpdated2;
	}

	public static Delegate UIPanel_OnClippingMoved(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPanel.OnClippingMoved(delegate(UIPanel param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPanel_OnClippingMoved_Event uIPanel_OnClippingMoved_Event = new DelegateFactory.UIPanel_OnClippingMoved_Event(func);
			UIPanel.OnClippingMoved onClippingMoved = new UIPanel.OnClippingMoved(uIPanel_OnClippingMoved_Event.Call);
			uIPanel_OnClippingMoved_Event.method = onClippingMoved.Method;
			return onClippingMoved;
		}
		DelegateFactory.UIPanel_OnClippingMoved_Event uIPanel_OnClippingMoved_Event2 = new DelegateFactory.UIPanel_OnClippingMoved_Event(func, self);
		UIPanel.OnClippingMoved onClippingMoved2 = new UIPanel.OnClippingMoved(uIPanel_OnClippingMoved_Event2.CallWithSelf);
		uIPanel_OnClippingMoved_Event2.method = onClippingMoved2.Method;
		return onClippingMoved2;
	}

	public static Delegate UILabel_ModifierFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UILabel.ModifierFunc((string param0) => null);
		}
		if (!flag)
		{
			DelegateFactory.UILabel_ModifierFunc_Event uILabel_ModifierFunc_Event = new DelegateFactory.UILabel_ModifierFunc_Event(func);
			UILabel.ModifierFunc modifierFunc = new UILabel.ModifierFunc(uILabel_ModifierFunc_Event.Call);
			uILabel_ModifierFunc_Event.method = modifierFunc.Method;
			return modifierFunc;
		}
		DelegateFactory.UILabel_ModifierFunc_Event uILabel_ModifierFunc_Event2 = new DelegateFactory.UILabel_ModifierFunc_Event(func, self);
		UILabel.ModifierFunc modifierFunc2 = new UILabel.ModifierFunc(uILabel_ModifierFunc_Event2.CallWithSelf);
		uILabel_ModifierFunc_Event2.method = modifierFunc2.Method;
		return modifierFunc2;
	}

	public static Delegate UIWidget_OnDrawCallChange(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.OnDrawCallChange(delegate(UIDrawCall param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_OnDrawCallChange_Event uIWidget_OnDrawCallChange_Event = new DelegateFactory.UIWidget_OnDrawCallChange_Event(func);
			UIWidget.OnDrawCallChange onDrawCallChange = new UIWidget.OnDrawCallChange(uIWidget_OnDrawCallChange_Event.Call);
			uIWidget_OnDrawCallChange_Event.method = onDrawCallChange.Method;
			return onDrawCallChange;
		}
		DelegateFactory.UIWidget_OnDrawCallChange_Event uIWidget_OnDrawCallChange_Event2 = new DelegateFactory.UIWidget_OnDrawCallChange_Event(func, self);
		UIWidget.OnDrawCallChange onDrawCallChange2 = new UIWidget.OnDrawCallChange(uIWidget_OnDrawCallChange_Event2.CallWithSelf);
		uIWidget_OnDrawCallChange_Event2.method = onDrawCallChange2.Method;
		return onDrawCallChange2;
	}

	public static Delegate UIWidget_OnDimensionsChanged(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.OnDimensionsChanged(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_OnDimensionsChanged_Event uIWidget_OnDimensionsChanged_Event = new DelegateFactory.UIWidget_OnDimensionsChanged_Event(func);
			UIWidget.OnDimensionsChanged onDimensionsChanged = new UIWidget.OnDimensionsChanged(uIWidget_OnDimensionsChanged_Event.Call);
			uIWidget_OnDimensionsChanged_Event.method = onDimensionsChanged.Method;
			return onDimensionsChanged;
		}
		DelegateFactory.UIWidget_OnDimensionsChanged_Event uIWidget_OnDimensionsChanged_Event2 = new DelegateFactory.UIWidget_OnDimensionsChanged_Event(func, self);
		UIWidget.OnDimensionsChanged onDimensionsChanged2 = new UIWidget.OnDimensionsChanged(uIWidget_OnDimensionsChanged_Event2.CallWithSelf);
		uIWidget_OnDimensionsChanged_Event2.method = onDimensionsChanged2.Method;
		return onDimensionsChanged2;
	}

	public static Delegate UIWidget_OnPostFillCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.OnPostFillCallback(delegate(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color> param4)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_OnPostFillCallback_Event uIWidget_OnPostFillCallback_Event = new DelegateFactory.UIWidget_OnPostFillCallback_Event(func);
			UIWidget.OnPostFillCallback onPostFillCallback = new UIWidget.OnPostFillCallback(uIWidget_OnPostFillCallback_Event.Call);
			uIWidget_OnPostFillCallback_Event.method = onPostFillCallback.Method;
			return onPostFillCallback;
		}
		DelegateFactory.UIWidget_OnPostFillCallback_Event uIWidget_OnPostFillCallback_Event2 = new DelegateFactory.UIWidget_OnPostFillCallback_Event(func, self);
		UIWidget.OnPostFillCallback onPostFillCallback2 = new UIWidget.OnPostFillCallback(uIWidget_OnPostFillCallback_Event2.CallWithSelf);
		uIWidget_OnPostFillCallback_Event2.method = onPostFillCallback2.Method;
		return onPostFillCallback2;
	}

	public static Delegate UIDrawCall_OnRenderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIDrawCall.OnRenderCallback(delegate(Material param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIDrawCall_OnRenderCallback_Event uIDrawCall_OnRenderCallback_Event = new DelegateFactory.UIDrawCall_OnRenderCallback_Event(func);
			UIDrawCall.OnRenderCallback onRenderCallback = new UIDrawCall.OnRenderCallback(uIDrawCall_OnRenderCallback_Event.Call);
			uIDrawCall_OnRenderCallback_Event.method = onRenderCallback.Method;
			return onRenderCallback;
		}
		DelegateFactory.UIDrawCall_OnRenderCallback_Event uIDrawCall_OnRenderCallback_Event2 = new DelegateFactory.UIDrawCall_OnRenderCallback_Event(func, self);
		UIDrawCall.OnRenderCallback onRenderCallback2 = new UIDrawCall.OnRenderCallback(uIDrawCall_OnRenderCallback_Event2.CallWithSelf);
		uIDrawCall_OnRenderCallback_Event2.method = onRenderCallback2.Method;
		return onRenderCallback2;
	}

	public static Delegate UIWidget_HitCheck(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.HitCheck((Vector3 param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_HitCheck_Event uIWidget_HitCheck_Event = new DelegateFactory.UIWidget_HitCheck_Event(func);
			UIWidget.HitCheck hitCheck = new UIWidget.HitCheck(uIWidget_HitCheck_Event.Call);
			uIWidget_HitCheck_Event.method = hitCheck.Method;
			return hitCheck;
		}
		DelegateFactory.UIWidget_HitCheck_Event uIWidget_HitCheck_Event2 = new DelegateFactory.UIWidget_HitCheck_Event(func, self);
		UIWidget.HitCheck hitCheck2 = new UIWidget.HitCheck(uIWidget_HitCheck_Event2.CallWithSelf);
		uIWidget_HitCheck_Event2.method = hitCheck2.Method;
		return hitCheck2;
	}

	public static Delegate UIGrid_OnReposition(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIGrid.OnReposition(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIGrid_OnReposition_Event uIGrid_OnReposition_Event = new DelegateFactory.UIGrid_OnReposition_Event(func);
			UIGrid.OnReposition onReposition = new UIGrid.OnReposition(uIGrid_OnReposition_Event.Call);
			uIGrid_OnReposition_Event.method = onReposition.Method;
			return onReposition;
		}
		DelegateFactory.UIGrid_OnReposition_Event uIGrid_OnReposition_Event2 = new DelegateFactory.UIGrid_OnReposition_Event(func, self);
		UIGrid.OnReposition onReposition2 = new UIGrid.OnReposition(uIGrid_OnReposition_Event2.CallWithSelf);
		uIGrid_OnReposition_Event2.method = onReposition2.Method;
		return onReposition2;
	}

	public static Delegate System_Comparison_UnityEngine_Transform(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<Transform>((Transform param0, Transform param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_UnityEngine_Transform_Event system_Comparison_UnityEngine_Transform_Event = new DelegateFactory.System_Comparison_UnityEngine_Transform_Event(func);
			Comparison<Transform> comparison = new Comparison<Transform>(system_Comparison_UnityEngine_Transform_Event.Call);
			system_Comparison_UnityEngine_Transform_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_UnityEngine_Transform_Event system_Comparison_UnityEngine_Transform_Event2 = new DelegateFactory.System_Comparison_UnityEngine_Transform_Event(func, self);
		Comparison<Transform> comparison2 = new Comparison<Transform>(system_Comparison_UnityEngine_Transform_Event2.CallWithSelf);
		system_Comparison_UnityEngine_Transform_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate UITable_OnReposition(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UITable.OnReposition(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UITable_OnReposition_Event uITable_OnReposition_Event = new DelegateFactory.UITable_OnReposition_Event(func);
			UITable.OnReposition onReposition = new UITable.OnReposition(uITable_OnReposition_Event.Call);
			uITable_OnReposition_Event.method = onReposition.Method;
			return onReposition;
		}
		DelegateFactory.UITable_OnReposition_Event uITable_OnReposition_Event2 = new DelegateFactory.UITable_OnReposition_Event(func, self);
		UITable.OnReposition onReposition2 = new UITable.OnReposition(uITable_OnReposition_Event2.CallWithSelf);
		uITable_OnReposition_Event2.method = onReposition2.Method;
		return onReposition2;
	}

	public static Delegate SpringPanel_OnFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SpringPanel.OnFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SpringPanel_OnFinished_Event springPanel_OnFinished_Event = new DelegateFactory.SpringPanel_OnFinished_Event(func);
			SpringPanel.OnFinished onFinished = new SpringPanel.OnFinished(springPanel_OnFinished_Event.Call);
			springPanel_OnFinished_Event.method = onFinished.Method;
			return onFinished;
		}
		DelegateFactory.SpringPanel_OnFinished_Event springPanel_OnFinished_Event2 = new DelegateFactory.SpringPanel_OnFinished_Event(func, self);
		SpringPanel.OnFinished onFinished2 = new SpringPanel.OnFinished(springPanel_OnFinished_Event2.CallWithSelf);
		springPanel_OnFinished_Event2.method = onFinished2.Method;
		return onFinished2;
	}

	public static Delegate UICenterOnChild_OnCenterCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICenterOnChild.OnCenterCallback(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICenterOnChild_OnCenterCallback_Event uICenterOnChild_OnCenterCallback_Event = new DelegateFactory.UICenterOnChild_OnCenterCallback_Event(func);
			UICenterOnChild.OnCenterCallback onCenterCallback = new UICenterOnChild.OnCenterCallback(uICenterOnChild_OnCenterCallback_Event.Call);
			uICenterOnChild_OnCenterCallback_Event.method = onCenterCallback.Method;
			return onCenterCallback;
		}
		DelegateFactory.UICenterOnChild_OnCenterCallback_Event uICenterOnChild_OnCenterCallback_Event2 = new DelegateFactory.UICenterOnChild_OnCenterCallback_Event(func, self);
		UICenterOnChild.OnCenterCallback onCenterCallback2 = new UICenterOnChild.OnCenterCallback(uICenterOnChild_OnCenterCallback_Event2.CallWithSelf);
		uICenterOnChild_OnCenterCallback_Event2.method = onCenterCallback2.Method;
		return onCenterCallback2;
	}

	public static Delegate Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICenterOnChildV2.OnDragFinishedCenter(() => null);
		}
		if (!flag)
		{
			DelegateFactory.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event = new DelegateFactory.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event(func);
			UICenterOnChildV2.OnDragFinishedCenter onDragFinishedCenter = new UICenterOnChildV2.OnDragFinishedCenter(assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event.Call);
			assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event.method = onDragFinishedCenter.Method;
			return onDragFinishedCenter;
		}
		DelegateFactory.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event2 = new DelegateFactory.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event(func, self);
		UICenterOnChildV2.OnDragFinishedCenter onDragFinishedCenter2 = new UICenterOnChildV2.OnDragFinishedCenter(assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event2.CallWithSelf);
		assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter_Event2.method = onDragFinishedCenter2.Method;
		return onDragFinishedCenter2;
	}

	public static Delegate UIWrapContent_OnInitializeItem(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWrapContent.OnInitializeItem(delegate(GameObject param0, int param1, int param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWrapContent_OnInitializeItem_Event uIWrapContent_OnInitializeItem_Event = new DelegateFactory.UIWrapContent_OnInitializeItem_Event(func);
			UIWrapContent.OnInitializeItem onInitializeItem = new UIWrapContent.OnInitializeItem(uIWrapContent_OnInitializeItem_Event.Call);
			uIWrapContent_OnInitializeItem_Event.method = onInitializeItem.Method;
			return onInitializeItem;
		}
		DelegateFactory.UIWrapContent_OnInitializeItem_Event uIWrapContent_OnInitializeItem_Event2 = new DelegateFactory.UIWrapContent_OnInitializeItem_Event(func, self);
		UIWrapContent.OnInitializeItem onInitializeItem2 = new UIWrapContent.OnInitializeItem(uIWrapContent_OnInitializeItem_Event2.CallWithSelf);
		uIWrapContent_OnInitializeItem_Event2.method = onInitializeItem2.Method;
		return onInitializeItem2;
	}

	public static Delegate System_Action_UnityEngine_Transform(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<Transform>(delegate(Transform param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_Transform_Event system_Action_UnityEngine_Transform_Event = new DelegateFactory.System_Action_UnityEngine_Transform_Event(func);
			Action<Transform> action = new Action<Transform>(system_Action_UnityEngine_Transform_Event.Call);
			system_Action_UnityEngine_Transform_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_Transform_Event system_Action_UnityEngine_Transform_Event2 = new DelegateFactory.System_Action_UnityEngine_Transform_Event(func, self);
		Action<Transform> action2 = new Action<Transform>(system_Action_UnityEngine_Transform_Event2.CallWithSelf);
		system_Action_UnityEngine_Transform_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UIToggle_Validate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIToggle.Validate((bool param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UIToggle_Validate_Event uIToggle_Validate_Event = new DelegateFactory.UIToggle_Validate_Event(func);
			UIToggle.Validate validate = new UIToggle.Validate(uIToggle_Validate_Event.Call);
			uIToggle_Validate_Event.method = validate.Method;
			return validate;
		}
		DelegateFactory.UIToggle_Validate_Event uIToggle_Validate_Event2 = new DelegateFactory.UIToggle_Validate_Event(func, self);
		UIToggle.Validate validate2 = new UIToggle.Validate(uIToggle_Validate_Event2.CallWithSelf);
		uIToggle_Validate_Event2.method = validate2.Method;
		return validate2;
	}

	public static Delegate UIScrollView_OnDragNotification(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIScrollView.OnDragNotification(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIScrollView_OnDragNotification_Event uIScrollView_OnDragNotification_Event = new DelegateFactory.UIScrollView_OnDragNotification_Event(func);
			UIScrollView.OnDragNotification onDragNotification = new UIScrollView.OnDragNotification(uIScrollView_OnDragNotification_Event.Call);
			uIScrollView_OnDragNotification_Event.method = onDragNotification.Method;
			return onDragNotification;
		}
		DelegateFactory.UIScrollView_OnDragNotification_Event uIScrollView_OnDragNotification_Event2 = new DelegateFactory.UIScrollView_OnDragNotification_Event(func, self);
		UIScrollView.OnDragNotification onDragNotification2 = new UIScrollView.OnDragNotification(uIScrollView_OnDragNotification_Event2.CallWithSelf);
		uIScrollView_OnDragNotification_Event2.method = onDragNotification2.Method;
		return onDragNotification2;
	}

	public static Delegate UIInput_OnValidate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIInput.OnValidate((string param0, int param1, char param2) => '\0');
		}
		if (!flag)
		{
			DelegateFactory.UIInput_OnValidate_Event uIInput_OnValidate_Event = new DelegateFactory.UIInput_OnValidate_Event(func);
			UIInput.OnValidate onValidate = new UIInput.OnValidate(uIInput_OnValidate_Event.Call);
			uIInput_OnValidate_Event.method = onValidate.Method;
			return onValidate;
		}
		DelegateFactory.UIInput_OnValidate_Event uIInput_OnValidate_Event2 = new DelegateFactory.UIInput_OnValidate_Event(func, self);
		UIInput.OnValidate onValidate2 = new UIInput.OnValidate(uIInput_OnValidate_Event2.CallWithSelf);
		uIInput_OnValidate_Event2.method = onValidate2.Method;
		return onValidate2;
	}

	public static Delegate UISectorWrapContent_OnWrapItem(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UISectorWrapContent.OnWrapItem(delegate(int param0, bool param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UISectorWrapContent_OnWrapItem_Event uISectorWrapContent_OnWrapItem_Event = new DelegateFactory.UISectorWrapContent_OnWrapItem_Event(func);
			UISectorWrapContent.OnWrapItem onWrapItem = new UISectorWrapContent.OnWrapItem(uISectorWrapContent_OnWrapItem_Event.Call);
			uISectorWrapContent_OnWrapItem_Event.method = onWrapItem.Method;
			return onWrapItem;
		}
		DelegateFactory.UISectorWrapContent_OnWrapItem_Event uISectorWrapContent_OnWrapItem_Event2 = new DelegateFactory.UISectorWrapContent_OnWrapItem_Event(func, self);
		UISectorWrapContent.OnWrapItem onWrapItem2 = new UISectorWrapContent.OnWrapItem(uISectorWrapContent_OnWrapItem_Event2.CallWithSelf);
		uISectorWrapContent_OnWrapItem_Event2.method = onWrapItem2.Method;
		return onWrapItem2;
	}

	public static Delegate UISectorWrapContent_SwitchToCenterPanel(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UISectorWrapContent.SwitchToCenterPanel(delegate(Transform param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UISectorWrapContent_SwitchToCenterPanel_Event uISectorWrapContent_SwitchToCenterPanel_Event = new DelegateFactory.UISectorWrapContent_SwitchToCenterPanel_Event(func);
			UISectorWrapContent.SwitchToCenterPanel switchToCenterPanel = new UISectorWrapContent.SwitchToCenterPanel(uISectorWrapContent_SwitchToCenterPanel_Event.Call);
			uISectorWrapContent_SwitchToCenterPanel_Event.method = switchToCenterPanel.Method;
			return switchToCenterPanel;
		}
		DelegateFactory.UISectorWrapContent_SwitchToCenterPanel_Event uISectorWrapContent_SwitchToCenterPanel_Event2 = new DelegateFactory.UISectorWrapContent_SwitchToCenterPanel_Event(func, self);
		UISectorWrapContent.SwitchToCenterPanel switchToCenterPanel2 = new UISectorWrapContent.SwitchToCenterPanel(uISectorWrapContent_SwitchToCenterPanel_Event2.CallWithSelf);
		uISectorWrapContent_SwitchToCenterPanel_Event2.method = switchToCenterPanel2.Method;
		return switchToCenterPanel2;
	}

	public static Delegate UIPopupMenu_OnPopupItemClick(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPopupMenu.OnPopupItemClick(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPopupMenu_OnPopupItemClick_Event uIPopupMenu_OnPopupItemClick_Event = new DelegateFactory.UIPopupMenu_OnPopupItemClick_Event(func);
			UIPopupMenu.OnPopupItemClick onPopupItemClick = new UIPopupMenu.OnPopupItemClick(uIPopupMenu_OnPopupItemClick_Event.Call);
			uIPopupMenu_OnPopupItemClick_Event.method = onPopupItemClick.Method;
			return onPopupItemClick;
		}
		DelegateFactory.UIPopupMenu_OnPopupItemClick_Event uIPopupMenu_OnPopupItemClick_Event2 = new DelegateFactory.UIPopupMenu_OnPopupItemClick_Event(func, self);
		UIPopupMenu.OnPopupItemClick onPopupItemClick2 = new UIPopupMenu.OnPopupItemClick(uIPopupMenu_OnPopupItemClick_Event2.CallWithSelf);
		uIPopupMenu_OnPopupItemClick_Event2.method = onPopupItemClick2.Method;
		return onPopupItemClick2;
	}

	public static Delegate SDK_CALLBACK(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SDK_CALLBACK(delegate(object[] param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SDK_CALLBACK_Event sDK_CALLBACK_Event = new DelegateFactory.SDK_CALLBACK_Event(func);
			SDK_CALLBACK sDK_CALLBACK = new SDK_CALLBACK(sDK_CALLBACK_Event.Call);
			sDK_CALLBACK_Event.method = sDK_CALLBACK.Method;
			return sDK_CALLBACK;
		}
		DelegateFactory.SDK_CALLBACK_Event sDK_CALLBACK_Event2 = new DelegateFactory.SDK_CALLBACK_Event(func, self);
		SDK_CALLBACK sDK_CALLBACK2 = new SDK_CALLBACK(sDK_CALLBACK_Event2.CallWithSelf);
		sDK_CALLBACK_Event2.method = sDK_CALLBACK2.Method;
		return sDK_CALLBACK2;
	}

	public static Delegate System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<UISelectionBtn>(delegate(UISelectionBtn param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event = new DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event(func);
			Action<UISelectionBtn> action = new Action<UISelectionBtn>(system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event.Call);
			system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event2 = new DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event(func, self);
		Action<UISelectionBtn> action2 = new Action<UISelectionBtn>(system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event2.CallWithSelf);
		system_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Func_UnityEngine_Transform_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Func<Transform, bool>((Transform param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Func_UnityEngine_Transform_bool_Event system_Func_UnityEngine_Transform_bool_Event = new DelegateFactory.System_Func_UnityEngine_Transform_bool_Event(func);
			Func<Transform, bool> func2 = new Func<Transform, bool>(system_Func_UnityEngine_Transform_bool_Event.Call);
			system_Func_UnityEngine_Transform_bool_Event.method = func2.Method;
			return func2;
		}
		DelegateFactory.System_Func_UnityEngine_Transform_bool_Event system_Func_UnityEngine_Transform_bool_Event2 = new DelegateFactory.System_Func_UnityEngine_Transform_bool_Event(func, self);
		Func<Transform, bool> func3 = new Func<Transform, bool>(system_Func_UnityEngine_Transform_bool_Event2.CallWithSelf);
		system_Func_UnityEngine_Transform_bool_Event2.method = func3.Method;
		return func3;
	}

	public static Delegate System_Action_Assets_Extends_EXNGUI_Compoment_UIClip(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<UIClip>(delegate(UIClip param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event = new DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event(func);
			Action<UIClip> action = new Action<UIClip>(system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event.Call);
			system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event2 = new DelegateFactory.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event(func, self);
		Action<UIClip> action2 = new Action<UIClip>(system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event2.CallWithSelf);
		system_Action_Assets_Extends_EXNGUI_Compoment_UIClip_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<GameObject>(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_Event = new DelegateFactory.System_Action_UnityEngine_GameObject_Event(func);
			Action<GameObject> action = new Action<GameObject>(system_Action_UnityEngine_GameObject_Event.Call);
			system_Action_UnityEngine_GameObject_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Action_UnityEngine_GameObject_Event(func, self);
		Action<GameObject> action2 = new Action<GameObject>(system_Action_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Action_UnityEngine_GameObject_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_GameObject_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<GameObject, GameObject>(delegate(GameObject param0, GameObject param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event = new DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event(func);
			Action<GameObject, GameObject> action = new Action<GameObject, GameObject>(system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event.Call);
			system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event(func, self);
		Action<GameObject, GameObject> action2 = new Action<GameObject, GameObject>(system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Action_UnityEngine_GameObject_UnityEngine_GameObject_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<GameObject, GameObject, GameObject>(delegate(GameObject param0, GameObject param1, GameObject param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event = new DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event(func);
			Action<GameObject, GameObject, GameObject> action = new Action<GameObject, GameObject, GameObject>(system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event.Call);
			system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event(func, self);
		Action<GameObject, GameObject, GameObject> action2 = new Action<GameObject, GameObject, GameObject>(system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Func_UnityEngine_GameObject_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Func<GameObject, GameObject>((GameObject param0) => null);
		}
		if (!flag)
		{
			DelegateFactory.System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event = new DelegateFactory.System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event(func);
			Func<GameObject, GameObject> func2 = new Func<GameObject, GameObject>(system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event.Call);
			system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event.method = func2.Method;
			return func2;
		}
		DelegateFactory.System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event(func, self);
		Func<GameObject, GameObject> func3 = new Func<GameObject, GameObject>(system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Func_UnityEngine_GameObject_UnityEngine_GameObject_Event2.method = func3.Method;
		return func3;
	}

	public static Delegate System_Func_UnityEngine_GameObject_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Func<GameObject, bool>((GameObject param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Func_UnityEngine_GameObject_bool_Event system_Func_UnityEngine_GameObject_bool_Event = new DelegateFactory.System_Func_UnityEngine_GameObject_bool_Event(func);
			Func<GameObject, bool> func2 = new Func<GameObject, bool>(system_Func_UnityEngine_GameObject_bool_Event.Call);
			system_Func_UnityEngine_GameObject_bool_Event.method = func2.Method;
			return func2;
		}
		DelegateFactory.System_Func_UnityEngine_GameObject_bool_Event system_Func_UnityEngine_GameObject_bool_Event2 = new DelegateFactory.System_Func_UnityEngine_GameObject_bool_Event(func, self);
		Func<GameObject, bool> func3 = new Func<GameObject, bool>(system_Func_UnityEngine_GameObject_bool_Event2.CallWithSelf);
		system_Func_UnityEngine_GameObject_bool_Event2.method = func3.Method;
		return func3;
	}

	public static Delegate System_Predicate_UIRoot(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<UIRoot>((UIRoot param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_UIRoot_Event system_Predicate_UIRoot_Event = new DelegateFactory.System_Predicate_UIRoot_Event(func);
			Predicate<UIRoot> predicate = new Predicate<UIRoot>(system_Predicate_UIRoot_Event.Call);
			system_Predicate_UIRoot_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_UIRoot_Event system_Predicate_UIRoot_Event2 = new DelegateFactory.System_Predicate_UIRoot_Event(func, self);
		Predicate<UIRoot> predicate2 = new Predicate<UIRoot>(system_Predicate_UIRoot_Event2.CallWithSelf);
		system_Predicate_UIRoot_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_UIRoot(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<UIRoot>(delegate(UIRoot param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UIRoot_Event system_Action_UIRoot_Event = new DelegateFactory.System_Action_UIRoot_Event(func);
			Action<UIRoot> action = new Action<UIRoot>(system_Action_UIRoot_Event.Call);
			system_Action_UIRoot_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UIRoot_Event system_Action_UIRoot_Event2 = new DelegateFactory.System_Action_UIRoot_Event(func, self);
		Action<UIRoot> action2 = new Action<UIRoot>(system_Action_UIRoot_Event2.CallWithSelf);
		system_Action_UIRoot_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_UIRoot(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<UIRoot>((UIRoot param0, UIRoot param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_UIRoot_Event system_Comparison_UIRoot_Event = new DelegateFactory.System_Comparison_UIRoot_Event(func);
			Comparison<UIRoot> comparison = new Comparison<UIRoot>(system_Comparison_UIRoot_Event.Call);
			system_Comparison_UIRoot_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_UIRoot_Event system_Comparison_UIRoot_Event2 = new DelegateFactory.System_Comparison_UIRoot_Event(func, self);
		Comparison<UIRoot> comparison2 = new Comparison<UIRoot>(system_Comparison_UIRoot_Event2.CallWithSelf);
		system_Comparison_UIRoot_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate System_Predicate_EventDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<EventDelegate>((EventDelegate param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_EventDelegate_Event system_Predicate_EventDelegate_Event = new DelegateFactory.System_Predicate_EventDelegate_Event(func);
			Predicate<EventDelegate> predicate = new Predicate<EventDelegate>(system_Predicate_EventDelegate_Event.Call);
			system_Predicate_EventDelegate_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_EventDelegate_Event system_Predicate_EventDelegate_Event2 = new DelegateFactory.System_Predicate_EventDelegate_Event(func, self);
		Predicate<EventDelegate> predicate2 = new Predicate<EventDelegate>(system_Predicate_EventDelegate_Event2.CallWithSelf);
		system_Predicate_EventDelegate_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_EventDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<EventDelegate>(delegate(EventDelegate param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_EventDelegate_Event system_Action_EventDelegate_Event = new DelegateFactory.System_Action_EventDelegate_Event(func);
			Action<EventDelegate> action = new Action<EventDelegate>(system_Action_EventDelegate_Event.Call);
			system_Action_EventDelegate_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_EventDelegate_Event system_Action_EventDelegate_Event2 = new DelegateFactory.System_Action_EventDelegate_Event(func, self);
		Action<EventDelegate> action2 = new Action<EventDelegate>(system_Action_EventDelegate_Event2.CallWithSelf);
		system_Action_EventDelegate_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_EventDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<EventDelegate>((EventDelegate param0, EventDelegate param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_EventDelegate_Event system_Comparison_EventDelegate_Event = new DelegateFactory.System_Comparison_EventDelegate_Event(func);
			Comparison<EventDelegate> comparison = new Comparison<EventDelegate>(system_Comparison_EventDelegate_Event.Call);
			system_Comparison_EventDelegate_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_EventDelegate_Event system_Comparison_EventDelegate_Event2 = new DelegateFactory.System_Comparison_EventDelegate_Event(func, self);
		Comparison<EventDelegate> comparison2 = new Comparison<EventDelegate>(system_Comparison_EventDelegate_Event2.CallWithSelf);
		system_Comparison_EventDelegate_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate SpringPosition_OnFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SpringPosition.OnFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SpringPosition_OnFinished_Event springPosition_OnFinished_Event = new DelegateFactory.SpringPosition_OnFinished_Event(func);
			SpringPosition.OnFinished onFinished = new SpringPosition.OnFinished(springPosition_OnFinished_Event.Call);
			springPosition_OnFinished_Event.method = onFinished.Method;
			return onFinished;
		}
		DelegateFactory.SpringPosition_OnFinished_Event springPosition_OnFinished_Event2 = new DelegateFactory.SpringPosition_OnFinished_Event(func, self);
		SpringPosition.OnFinished onFinished2 = new SpringPosition.OnFinished(springPosition_OnFinished_Event2.CallWithSelf);
		springPosition_OnFinished_Event2.method = onFinished2.Method;
		return onFinished2;
	}

	public static Delegate System_Action_Assets_Scripts_Game_IGameEntryTask_float_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<IGameEntryTask, float, string>(delegate(IGameEntryTask param0, float param1, string param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event = new DelegateFactory.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event(func);
			Action<IGameEntryTask, float, string> action = new Action<IGameEntryTask, float, string>(system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event.Call);
			system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event2 = new DelegateFactory.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event(func, self);
		Action<IGameEntryTask, float, string> action2 = new Action<IGameEntryTask, float, string>(system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event2.CallWithSelf);
		system_Action_Assets_Scripts_Game_IGameEntryTask_float_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_Vector2(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<Vector2>(delegate(Vector2 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_Vector2_Event system_Action_UnityEngine_Vector2_Event = new DelegateFactory.System_Action_UnityEngine_Vector2_Event(func);
			Action<Vector2> action = new Action<Vector2>(system_Action_UnityEngine_Vector2_Event.Call);
			system_Action_UnityEngine_Vector2_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_Vector2_Event system_Action_UnityEngine_Vector2_Event2 = new DelegateFactory.System_Action_UnityEngine_Vector2_Event(func, self);
		Action<Vector2> action2 = new Action<Vector2>(system_Action_UnityEngine_Vector2_Event2.CallWithSelf);
		system_Action_UnityEngine_Vector2_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UIProgressBar_OnDragFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIProgressBar.OnDragFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIProgressBar_OnDragFinished_Event uIProgressBar_OnDragFinished_Event = new DelegateFactory.UIProgressBar_OnDragFinished_Event(func);
			UIProgressBar.OnDragFinished onDragFinished = new UIProgressBar.OnDragFinished(uIProgressBar_OnDragFinished_Event.Call);
			uIProgressBar_OnDragFinished_Event.method = onDragFinished.Method;
			return onDragFinished;
		}
		DelegateFactory.UIProgressBar_OnDragFinished_Event uIProgressBar_OnDragFinished_Event2 = new DelegateFactory.UIProgressBar_OnDragFinished_Event(func, self);
		UIProgressBar.OnDragFinished onDragFinished2 = new UIProgressBar.OnDragFinished(uIProgressBar_OnDragFinished_Event2.CallWithSelf);
		uIProgressBar_OnDragFinished_Event2.method = onDragFinished2.Method;
		return onDragFinished2;
	}

	public static Delegate System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Func<Transform, int, Vector3, Vector3>((Transform param0, int param1, Vector3 param2) => default(Vector3));
		}
		if (!flag)
		{
			DelegateFactory.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event = new DelegateFactory.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event(func);
			Func<Transform, int, Vector3, Vector3> func2 = new Func<Transform, int, Vector3, Vector3>(system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event.Call);
			system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event.method = func2.Method;
			return func2;
		}
		DelegateFactory.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event2 = new DelegateFactory.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event(func, self);
		Func<Transform, int, Vector3, Vector3> func3 = new Func<Transform, int, Vector3, Vector3>(system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event2.CallWithSelf);
		system_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3_Event2.method = func3.Method;
		return func3;
	}

	public static Delegate UIDrawCall_OnRenderQueueChange(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIDrawCall.OnRenderQueueChange(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIDrawCall_OnRenderQueueChange_Event uIDrawCall_OnRenderQueueChange_Event = new DelegateFactory.UIDrawCall_OnRenderQueueChange_Event(func);
			UIDrawCall.OnRenderQueueChange onRenderQueueChange = new UIDrawCall.OnRenderQueueChange(uIDrawCall_OnRenderQueueChange_Event.Call);
			uIDrawCall_OnRenderQueueChange_Event.method = onRenderQueueChange.Method;
			return onRenderQueueChange;
		}
		DelegateFactory.UIDrawCall_OnRenderQueueChange_Event uIDrawCall_OnRenderQueueChange_Event2 = new DelegateFactory.UIDrawCall_OnRenderQueueChange_Event(func, self);
		UIDrawCall.OnRenderQueueChange onRenderQueueChange2 = new UIDrawCall.OnRenderQueueChange(uIDrawCall_OnRenderQueueChange_Event2.CallWithSelf);
		uIDrawCall_OnRenderQueueChange_Event2.method = onRenderQueueChange2.Method;
		return onRenderQueueChange2;
	}

	public static Delegate System_Action_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<string>(delegate(string param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_string_Event system_Action_string_Event = new DelegateFactory.System_Action_string_Event(func);
			Action<string> action = new Action<string>(system_Action_string_Event.Call);
			system_Action_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_string_Event system_Action_string_Event2 = new DelegateFactory.System_Action_string_Event(func, self);
		Action<string> action2 = new Action<string>(system_Action_string_Event2.CallWithSelf);
		system_Action_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<bool>(delegate(bool param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_bool_Event system_Action_bool_Event = new DelegateFactory.System_Action_bool_Event(func);
			Action<bool> action = new Action<bool>(system_Action_bool_Event.Call);
			system_Action_bool_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_bool_Event system_Action_bool_Event2 = new DelegateFactory.System_Action_bool_Event(func, self);
		Action<bool> action2 = new Action<bool>(system_Action_bool_Event2.CallWithSelf);
		system_Action_bool_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Predicate_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<GameObject>((GameObject param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_UnityEngine_GameObject_Event system_Predicate_UnityEngine_GameObject_Event = new DelegateFactory.System_Predicate_UnityEngine_GameObject_Event(func);
			Predicate<GameObject> predicate = new Predicate<GameObject>(system_Predicate_UnityEngine_GameObject_Event.Call);
			system_Predicate_UnityEngine_GameObject_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_UnityEngine_GameObject_Event system_Predicate_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Predicate_UnityEngine_GameObject_Event(func, self);
		Predicate<GameObject> predicate2 = new Predicate<GameObject>(system_Predicate_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Predicate_UnityEngine_GameObject_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Comparison_UnityEngine_GameObject(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<GameObject>((GameObject param0, GameObject param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_UnityEngine_GameObject_Event system_Comparison_UnityEngine_GameObject_Event = new DelegateFactory.System_Comparison_UnityEngine_GameObject_Event(func);
			Comparison<GameObject> comparison = new Comparison<GameObject>(system_Comparison_UnityEngine_GameObject_Event.Call);
			system_Comparison_UnityEngine_GameObject_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_UnityEngine_GameObject_Event system_Comparison_UnityEngine_GameObject_Event2 = new DelegateFactory.System_Comparison_UnityEngine_GameObject_Event(func, self);
		Comparison<GameObject> comparison2 = new Comparison<GameObject>(system_Comparison_UnityEngine_GameObject_Event2.CallWithSelf);
		system_Comparison_UnityEngine_GameObject_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate System_Predicate_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<string>((string param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_string_Event system_Predicate_string_Event = new DelegateFactory.System_Predicate_string_Event(func);
			Predicate<string> predicate = new Predicate<string>(system_Predicate_string_Event.Call);
			system_Predicate_string_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_string_Event system_Predicate_string_Event2 = new DelegateFactory.System_Predicate_string_Event(func, self);
		Predicate<string> predicate2 = new Predicate<string>(system_Predicate_string_Event2.CallWithSelf);
		system_Predicate_string_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Comparison_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<string>((string param0, string param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_string_Event system_Comparison_string_Event = new DelegateFactory.System_Comparison_string_Event(func);
			Comparison<string> comparison = new Comparison<string>(system_Comparison_string_Event.Call);
			system_Comparison_string_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_string_Event system_Comparison_string_Event2 = new DelegateFactory.System_Comparison_string_Event(func, self);
		Comparison<string> comparison2 = new Comparison<string>(system_Comparison_string_Event2.CallWithSelf);
		system_Comparison_string_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate System_Predicate_object(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<object>((object param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_object_Event system_Predicate_object_Event = new DelegateFactory.System_Predicate_object_Event(func);
			Predicate<object> predicate = new Predicate<object>(system_Predicate_object_Event.Call);
			system_Predicate_object_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_object_Event system_Predicate_object_Event2 = new DelegateFactory.System_Predicate_object_Event(func, self);
		Predicate<object> predicate2 = new Predicate<object>(system_Predicate_object_Event2.CallWithSelf);
		system_Predicate_object_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_object(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<object>(delegate(object param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_object_Event system_Action_object_Event = new DelegateFactory.System_Action_object_Event(func);
			Action<object> action = new Action<object>(system_Action_object_Event.Call);
			system_Action_object_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_object_Event system_Action_object_Event2 = new DelegateFactory.System_Action_object_Event(func, self);
		Action<object> action2 = new Action<object>(system_Action_object_Event2.CallWithSelf);
		system_Action_object_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_object(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<object>((object param0, object param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_object_Event system_Comparison_object_Event = new DelegateFactory.System_Comparison_object_Event(func);
			Comparison<object> comparison = new Comparison<object>(system_Comparison_object_Event.Call);
			system_Comparison_object_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_object_Event system_Comparison_object_Event2 = new DelegateFactory.System_Comparison_object_Event(func, self);
		Comparison<object> comparison2 = new Comparison<object>(system_Comparison_object_Event2.CallWithSelf);
		system_Comparison_object_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate BetterList_UICamera_CompareFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new BetterList<UICamera>.CompareFunc((UICamera param0, UICamera param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.BetterList_UICamera_CompareFunc_Event betterList_UICamera_CompareFunc_Event = new DelegateFactory.BetterList_UICamera_CompareFunc_Event(func);
			BetterList<UICamera>.CompareFunc compareFunc = new BetterList<UICamera>.CompareFunc(betterList_UICamera_CompareFunc_Event.Call);
			betterList_UICamera_CompareFunc_Event.method = compareFunc.Method;
			return compareFunc;
		}
		DelegateFactory.BetterList_UICamera_CompareFunc_Event betterList_UICamera_CompareFunc_Event2 = new DelegateFactory.BetterList_UICamera_CompareFunc_Event(func, self);
		BetterList<UICamera>.CompareFunc compareFunc2 = new BetterList<UICamera>.CompareFunc(betterList_UICamera_CompareFunc_Event2.CallWithSelf);
		betterList_UICamera_CompareFunc_Event2.method = compareFunc2.Method;
		return compareFunc2;
	}
}
