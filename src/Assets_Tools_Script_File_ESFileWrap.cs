using Assets.Tools.Script.File;
using LuaInterface;
using System;
using System.IO;
using System.Text;

public class Assets_Tools_Script_File_ESFileWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ESFile), typeof(object), null);
		L.RegFunction("LoadString", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.LoadString));
		L.RegFunction("Save", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.Save));
		L.RegFunction("SaveAsCreate", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.SaveAsCreate));
		L.RegFunction("SaveAsAppend", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.SaveAsAppend));
		L.RegFunction("SaveRaw", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.SaveRaw));
		L.RegFunction("LoadRaw", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.LoadRaw));
		L.RegFunction("SaveXMLObject", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.SaveXMLObject));
		L.RegFunction("Exists", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.Exists));
		L.RegFunction("Delete", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.Delete));
		L.RegFunction("GetFiles", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.GetFiles));
		L.RegFunction("HoldStreamWriter", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.HoldStreamWriter));
		L.RegFunction("ReleaseStreamWriter", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.ReleaseStreamWriter));
		L.RegFunction("CreateORwriteFile", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.CreateORwriteFile));
		L.RegFunction("ReadStringFile", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.ReadStringFile));
		L.RegFunction("ReadBytesFile", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap.ReadBytesFile));
		L.RegFunction("New", new LuaCSFunction(Assets_Tools_Script_File_ESFileWrap._CreateAssets_Tools_Script_File_ESFile));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAssets_Tools_Script_File_ESFile(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				ESFile o = new ESFile();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Assets.Tools.Script.File.ESFile.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			string str = ESFile.LoadString(path);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string info = ToLua.CheckString(L, 1);
			string path = ToLua.CheckString(L, 2);
			FileMode mode = (FileMode)LuaDLL.luaL_checknumber(L, 3);
			ESFile.Save(info, path, mode);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveAsCreate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string info = ToLua.CheckString(L, 1);
			string path = ToLua.CheckString(L, 2);
			ESFile.SaveAsCreate(info, path);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveAsAppend(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string info = ToLua.CheckString(L, 1);
			string path = ToLua.CheckString(L, 2);
			ESFile.SaveAsAppend(info, path);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveRaw(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			byte[] bytes = ToLua.CheckByteBuffer(L, 1);
			string path = ToLua.CheckString(L, 2);
			ESFile.SaveRaw(bytes, path);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadRaw(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			byte[] array = ESFile.LoadRaw(path);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SaveXMLObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string path = ToLua.CheckString(L, 1);
			object objToSerialize = ToLua.ToVarObject(L, 2);
			ESFile.SaveXMLObject(path, objToSerialize);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Exists(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			bool value = ESFile.Exists(path);
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Delete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			ESFile.Delete(path);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFiles(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string folderPath = ToLua.CheckString(L, 1);
			string[] files = ESFile.GetFiles(folderPath);
			ToLua.Push(L, files);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HoldStreamWriter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string path = ToLua.CheckString(L, 1);
			FileMode mode = (FileMode)LuaDLL.luaL_checknumber(L, 2);
			Encoding encoding = (Encoding)ToLua.CheckObject(L, 3, typeof(Encoding));
			ESFile.HoldStreamWriter(path, mode, encoding);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReleaseStreamWriter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			ESFile.ReleaseStreamWriter(path);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateORwriteFile(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(byte[]), typeof(uint)))
			{
				string path = ToLua.ToString(L, 1);
				byte[] info = ToLua.CheckByteBuffer(L, 2);
				FileMode mode = (FileMode)LuaDLL.lua_tonumber(L, 3);
				ESFile.CreateORwriteFile(path, info, mode);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string), typeof(uint)))
			{
				string path2 = ToLua.ToString(L, 1);
				string info2 = ToLua.ToString(L, 2);
				FileMode mode2 = (FileMode)LuaDLL.lua_tonumber(L, 3);
				ESFile.CreateORwriteFile(path2, info2, mode2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Assets.Tools.Script.File.ESFile.CreateORwriteFile");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadStringFile(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			string str = ESFile.ReadStringFile(path);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReadBytesFile(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string path = ToLua.CheckString(L, 1);
			byte[] array = ESFile.ReadBytesFile(path);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
