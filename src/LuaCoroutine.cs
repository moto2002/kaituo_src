using LuaInterface;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public static class LuaCoroutine
{
	private static MonoBehaviour mb;

	private static string strCo = "\r\n        local _WaitForSeconds, _WaitForFixedUpdate, _WaitForEndOfFrame, _Yield, _StopCoroutine = WaitForSeconds, WaitForFixedUpdate, WaitForEndOfFrame, Yield, StopCoroutine        \r\n        local error = error\r\n        local debug = debug\r\n        local coroutine = coroutine\r\n        local comap = {}\r\n        setmetatable(comap, {__mode = 'k'})\r\n\r\n        function _resume(co)\r\n            if comap[co] then\r\n                comap[co] = nil\r\n                local flag, msg = coroutine.resume(co)\r\n                    \r\n                if not flag then\r\n                    msg = debug.traceback(co, msg)\r\n                    error(msg)\r\n                end\r\n            end        \r\n        end\r\n\r\n        function WaitForSeconds(t)\r\n            local co = coroutine.running()\r\n            local resume = function()                    \r\n                _resume(co)                     \r\n            end\r\n            \r\n            comap[co] = _WaitForSeconds(t, resume)\r\n            return coroutine.yield()\r\n        end\r\n\r\n        function WaitForFixedUpdate()\r\n            local co = coroutine.running()\r\n            local resume = function()          \r\n                _resume(co)     \r\n            end\r\n        \r\n            comap[co] = _WaitForFixedUpdate(resume)\r\n            return coroutine.yield()\r\n        end\r\n\r\n        function WaitForEndOfFrame()\r\n            local co = coroutine.running()\r\n            local resume = function()        \r\n                _resume(co)     \r\n            end\r\n        \r\n            comap[co] = _WaitForEndOfFrame(resume)\r\n            return coroutine.yield()\r\n        end\r\n\r\n        function Yield(o)\r\n            local co = coroutine.running()\r\n            local resume = function()        \r\n                _resume(co)     \r\n            end\r\n        \r\n            comap[co] = _Yield(o, resume)\r\n            return coroutine.yield()\r\n        end\r\n\r\n        function StartCoroutine(func)\r\n            local co = coroutine.create(func)                       \r\n            local flag, msg = coroutine.resume(co)\r\n\r\n            if not flag then\r\n                msg = debug.traceback(co, msg)\r\n                error(msg)\r\n            end\r\n\r\n            return co\r\n        end\r\n\r\n        function StopCoroutine(co)\r\n            local _co = comap[co]\r\n\r\n            if _co == nil then\r\n                return\r\n            end\r\n\r\n            comap[co] = nil\r\n            _StopCoroutine(_co)\r\n        end\r\n        ";

	public static void Register(LuaState state, MonoBehaviour behaviour)
	{
		state.BeginModule(null);
		state.RegFunction("WaitForSeconds", new LuaCSFunction(LuaCoroutine.WaitForSeconds));
		state.RegFunction("WaitForFixedUpdate", new LuaCSFunction(LuaCoroutine.WaitForFixedUpdate));
		state.RegFunction("WaitForEndOfFrame", new LuaCSFunction(LuaCoroutine.WaitForEndOfFrame));
		state.RegFunction("Yield", new LuaCSFunction(LuaCoroutine.Yield));
		state.RegFunction("StopCoroutine", new LuaCSFunction(LuaCoroutine.StopCoroutine));
		state.EndModule();
		state.LuaDoString(LuaCoroutine.strCo, "LuaCoroutine.cs");
		LuaCoroutine.mb = behaviour;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForSeconds(IntPtr L)
	{
		int result;
		try
		{
			float sec = (float)LuaDLL.luaL_checknumber(L, 1);
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForSeconds(sec, func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForSeconds(float sec, LuaFunction func)
	{
		LuaCoroutine.<CoWaitForSeconds>c__Iterator0 <CoWaitForSeconds>c__Iterator = new LuaCoroutine.<CoWaitForSeconds>c__Iterator0();
		<CoWaitForSeconds>c__Iterator.sec = sec;
		<CoWaitForSeconds>c__Iterator.func = func;
		<CoWaitForSeconds>c__Iterator.<$>sec = sec;
		<CoWaitForSeconds>c__Iterator.<$>func = func;
		return <CoWaitForSeconds>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForFixedUpdate(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 1);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForFixedUpdate(func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForFixedUpdate(LuaFunction func)
	{
		LuaCoroutine.<CoWaitForFixedUpdate>c__Iterator1 <CoWaitForFixedUpdate>c__Iterator = new LuaCoroutine.<CoWaitForFixedUpdate>c__Iterator1();
		<CoWaitForFixedUpdate>c__Iterator.func = func;
		<CoWaitForFixedUpdate>c__Iterator.<$>func = func;
		return <CoWaitForFixedUpdate>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForEndOfFrame(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.ToLuaFunction(L, 1);
			Coroutine o = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoWaitForEndOfFrame(func));
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoWaitForEndOfFrame(LuaFunction func)
	{
		LuaCoroutine.<CoWaitForEndOfFrame>c__Iterator2 <CoWaitForEndOfFrame>c__Iterator = new LuaCoroutine.<CoWaitForEndOfFrame>c__Iterator2();
		<CoWaitForEndOfFrame>c__Iterator.func = func;
		<CoWaitForEndOfFrame>c__Iterator.<$>func = func;
		return <CoWaitForEndOfFrame>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Yield(IntPtr L)
	{
		int result;
		try
		{
			object o = ToLua.ToVarObject(L, 1);
			LuaFunction func = ToLua.ToLuaFunction(L, 2);
			Coroutine o2 = LuaCoroutine.mb.StartCoroutine(LuaCoroutine.CoYield(o, func));
			ToLua.PushObject(L, o2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[DebuggerHidden]
	private static IEnumerator CoYield(object o, LuaFunction func)
	{
		LuaCoroutine.<CoYield>c__Iterator3 <CoYield>c__Iterator = new LuaCoroutine.<CoYield>c__Iterator3();
		<CoYield>c__Iterator.o = o;
		<CoYield>c__Iterator.func = func;
		<CoYield>c__Iterator.<$>o = o;
		<CoYield>c__Iterator.<$>func = func;
		return <CoYield>c__Iterator;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopCoroutine(IntPtr L)
	{
		int result;
		try
		{
			Coroutine routine = (Coroutine)ToLua.CheckObject(L, 1, typeof(Coroutine));
			LuaCoroutine.mb.StopCoroutine(routine);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
