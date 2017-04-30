using ParadoxNotion;
using System;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class ReflectedAction : ReflectedActionWrapper
	{
		private Action call;

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[0];
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override void Call()
		{
			this.call();
		}
	}
	[Serializable]
	public class ReflectedAction<T1> : ReflectedActionWrapper
	{
		private Action<T1> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.p1
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override void Call()
		{
			this.call(this.p1.value);
		}
	}
	[Serializable]
	public class ReflectedAction<T1, T2> : ReflectedActionWrapper
	{
		private Action<T1, T2> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		public BBParameter<T2> p2 = new BBParameter<T2>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.p1,
				this.p2
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override void Call()
		{
			this.call(this.p1.value, this.p2.value);
		}
	}
	[Serializable]
	public class ReflectedAction<T1, T2, T3> : ReflectedActionWrapper
	{
		private Action<T1, T2, T3> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		public BBParameter<T2> p2 = new BBParameter<T2>();

		public BBParameter<T3> p3 = new BBParameter<T3>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.p1,
				this.p2,
				this.p3
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override void Call()
		{
			this.call(this.p1.value, this.p2.value, this.p3.value);
		}
	}
}
