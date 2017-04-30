using System;
using System.Runtime.Serialization;

namespace XQ.Framework.Utility
{
	public class WeakReference<T> : WeakReference
	{
		public new T Target
		{
			get
			{
				return (T)((object)base.Target);
			}
			set
			{
				base.Target = value;
			}
		}

		public WeakReference(T target) : base(target)
		{
		}

		public WeakReference(T target, bool trackResurrection) : base(target, trackResurrection)
		{
		}

		protected WeakReference(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
