using ParadoxNotion;
using System;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class ReflectedFunction<TResult> : ReflectedFunctionWrapper
	{
		private Func<TResult> call;

		[BlackboardOnly]
		public BBParameter<TResult> result = new BBParameter<TResult>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.result
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override object Call()
		{
			TResult tResult = this.call();
			this.result.value = tResult;
			return tResult;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1> : ReflectedFunctionWrapper
	{
		private Func<T1, TResult> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		[BlackboardOnly]
		public BBParameter<TResult> result = new BBParameter<TResult>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.result,
				this.p1
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override object Call()
		{
			TResult tResult = this.call(this.p1.value);
			this.result.value = tResult;
			return tResult;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2> : ReflectedFunctionWrapper
	{
		private Func<T1, T2, TResult> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		public BBParameter<T2> p2 = new BBParameter<T2>();

		[BlackboardOnly]
		public BBParameter<TResult> result = new BBParameter<TResult>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.result,
				this.p1,
				this.p2
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override object Call()
		{
			TResult tResult = this.call(this.p1.value, this.p2.value);
			this.result.value = tResult;
			return tResult;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2, T3> : ReflectedFunctionWrapper
	{
		private Func<T1, T2, T3, TResult> call;

		public BBParameter<T1> p1 = new BBParameter<T1>();

		public BBParameter<T2> p2 = new BBParameter<T2>();

		public BBParameter<T3> p3 = new BBParameter<T3>();

		[BlackboardOnly]
		public BBParameter<TResult> result = new BBParameter<TResult>();

		public override BBParameter[] GetVariables()
		{
			return new BBParameter[]
			{
				this.result,
				this.p1,
				this.p2,
				this.p3
			};
		}

		public override void Init(object instance)
		{
			this.call = base.GetMethod().RTCreateDelegate(instance);
		}

		public override object Call()
		{
			TResult tResult = this.call(this.p1.value, this.p2.value, this.p3.value);
			this.result.value = tResult;
			return tResult;
		}
	}
}
