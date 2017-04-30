using LuaInterface;
using System;

public class DelegateExt
{
	private class DelegateExtActionObject : LuaDelegate
	{
		public DelegateExtActionObject(LuaFunction func) : base(func)
		{
		}

		public void Call()
		{
			Action<object> obj = delegate(object r)
			{
			};
			Action<int> action = delegate(int r)
			{
				obj(r);
			};
			action(123);
			this.func.BeginPCall();
			this.func.PCall();
			this.func.EndPCall();
		}

		public void Call(object p0)
		{
			this.func.BeginPCall();
			this.func.Push(p0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void Call(object p0, object p1)
		{
			this.func.BeginPCall();
			this.func.Push(p0);
			this.func.Push(p1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void Call(object p0, object p1, object p2)
		{
			this.func.BeginPCall();
			this.func.Push(p0);
			this.func.Push(p1);
			this.func.Push(p2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void Call(object p0, object p1, object p2, object p3)
		{
			this.func.BeginPCall();
			this.func.Push(p0);
			this.func.Push(p1);
			this.func.Push(p2);
			this.func.Push(p3);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	public static Delegate Action(int argCnt, LuaFunction func)
	{
		if (func == null)
		{
			return new Action(delegate
			{
			});
		}
		switch (argCnt)
		{
		case 0:
			return new Action(new DelegateExt.DelegateExtActionObject(func).Call);
		case 1:
			return new Action<object>(new DelegateExt.DelegateExtActionObject(func).Call);
		case 2:
			return new Action<object, object>(new DelegateExt.DelegateExtActionObject(func).Call);
		case 3:
			return new Action<object, object, object>(new DelegateExt.DelegateExtActionObject(func).Call);
		case 4:
			return new Action<object, object, object, object>(new DelegateExt.DelegateExtActionObject(func).Call);
		default:
			return null;
		}
	}
}
