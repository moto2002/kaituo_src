using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestLuaCallBack : MonoBehaviour
{
	private string lua = "\nlocal aaa = 1\nlocal bbb = 1\nlocal ccc = 1\n\nprint(ccc)\n";

	public string FileName;

	private LuaManager message;

	private LuaFunction luaFunction;

	private Dictionary<LuaFunction, int> dic = new Dictionary<LuaFunction, int>();

	private void Start()
	{
		this.message = base.gameObject.AddComponent<LuaManager>();
		this.message.DoFile(this.FileName);
	}

	private void Test2()
	{
		this.luaFunction = null;
	}
}
