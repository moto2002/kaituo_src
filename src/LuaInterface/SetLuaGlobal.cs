using System;
using System.Collections.Generic;
using XQ.Framework.Utility.Debug;

namespace LuaInterface
{
	public static class SetLuaGlobal
	{
		public static List<Action<LuaState>> RegLuaVariable = new List<Action<LuaState>>();

		public static void RegGlobal(LuaState lstate)
		{
			LuaDLL.tolua_pushcfunction(lstate.L, new LuaCSFunction(SetLuaGlobal.Printf));
			LuaDLL.lua_setglobal(lstate.L, "printfinfo");
			LuaDLL.tolua_pushcfunction(lstate.L, new LuaCSFunction(SetLuaGlobal.PrintfWarn));
			LuaDLL.lua_setglobal(lstate.L, "printfwarn");
			LuaDLL.tolua_pushcfunction(lstate.L, new LuaCSFunction(SetLuaGlobal.PrintfError));
			LuaDLL.lua_setglobal(lstate.L, "printferror");
			LuaDLL.tolua_pushcfunction(lstate.L, new LuaCSFunction(SetLuaGlobal.PrintfException));
			LuaDLL.lua_setglobal(lstate.L, "printfexception");
			LuaDLL.lua_getglobal(lstate.L, "tolua");
			LuaDLL.lua_pushstring(lstate.L, "debugmode");
			LuaDLL.tolua_pushcfunction(lstate.L, new LuaCSFunction(SetLuaGlobal.DebugMode));
			LuaDLL.lua_rawset(lstate.L, -3);
			LuaDLL.lua_pushboolean(lstate.L, false);
			LuaDLL.lua_setglobal(lstate.L, "ismac");
			LuaDLL.lua_pushboolean(lstate.L, false);
			LuaDLL.lua_setglobal(lstate.L, "iseditor");
			LuaDLL.lua_pushboolean(lstate.L, false);
			LuaDLL.lua_setglobal(lstate.L, "isiphone");
			LuaDLL.lua_pushboolean(lstate.L, true);
			LuaDLL.lua_setglobal(lstate.L, "isandroid");
			LuaDLL.lua_pushboolean(lstate.L, false);
			LuaDLL.lua_setglobal(lstate.L, "isstandalonewin");
			LuaDLL.lua_pushboolean(lstate.L, false);
			LuaDLL.lua_setglobal(lstate.L, "isdebugscript");
			SetLuaGlobal.RegLuaVariable.ForEach(delegate(Action<LuaState> r)
			{
				r(lstate);
			});
			SetLuaGlobal.RegLuaVariable.Clear();
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int DebugMode(IntPtr L)
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				LuaDLL.lua_pushboolean(L, false);
			}
			else
			{
				UDebug.OpenLog = LuaDLL.lua_isboolean(L, 1);
				LuaDLL.lua_pushboolean(L, UDebug.OpenLog);
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int Printf(IntPtr L)
		{
			return SetLuaGlobal.PrintInfo(L, 1);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int PrintfWarn(IntPtr L)
		{
			return SetLuaGlobal.PrintInfo(L, 2);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int PrintfError(IntPtr L)
		{
			return SetLuaGlobal.PrintInfo(L, 3);
		}

		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		private static int PrintfException(IntPtr L)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 1)
				{
					UDebug.Error(LuaDLL.lua_tostring(L, 1), new object[0]);
				}
				else
				{
					UDebug.Error(LuaDLL.lua_tostring(L, 1), new object[]
					{
						LuaDLL.lua_tostring(L, 2)
					});
				}
				result = 0;
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}

		private static int PrintInfo(IntPtr L, int logType)
		{
			int result;
			try
			{
				int num = LuaDLL.lua_gettop(L);
				if (num == 1)
				{
					switch (logType)
					{
					case 1:
						UDebug.Debug(LuaDLL.lua_tostring(L, 1), new object[0]);
						break;
					case 2:
						UDebug.Warn(LuaDLL.lua_tostring(L, 1), new object[0]);
						break;
					case 3:
						UDebug.Error(LuaDLL.lua_tostring(L, 1), new object[0]);
						break;
					}
					result = 0;
				}
				else
				{
					object[] array = new object[num - 1];
					int i = 2;
					int num2 = 0;
					int num3 = num + 1;
					while (i < num3)
					{
						if (LuaDLL.lua_isstring(L, i) == 1)
						{
							array[num2++] = LuaDLL.lua_tostring(L, i);
						}
						else if (LuaDLL.lua_isnil(L, i))
						{
							array[num2++] = "nil";
						}
						else if (LuaDLL.lua_isboolean(L, i))
						{
							array[num2++] = ((!LuaDLL.lua_toboolean(L, i)) ? "false" : "true");
						}
						else
						{
							IntPtr value = LuaDLL.lua_topointer(L, i);
							if (value == IntPtr.Zero)
							{
								array[num2++] = "nil";
							}
							else
							{
								array[num2++] = string.Format("{0}:0x{1}", LuaDLL.luaL_typename(L, i), value.ToString("X"));
							}
						}
						i++;
					}
					switch (logType)
					{
					case 1:
						UDebug.Debug(LuaDLL.lua_tostring(L, 1), array);
						break;
					case 2:
						UDebug.Warn(LuaDLL.lua_tostring(L, 1), array);
						break;
					case 3:
						UDebug.Error(LuaDLL.lua_tostring(L, 1), array);
						break;
					}
					result = 0;
				}
			}
			catch (Exception e)
			{
				result = LuaDLL.toluaL_exception(L, e, null);
			}
			return result;
		}
	}
}
