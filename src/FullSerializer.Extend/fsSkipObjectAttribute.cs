using System;

namespace FullSerializer.Extend
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class fsSkipObjectAttribute : Attribute
	{
		public Type ValueType;

		public fsSkipObjectAttribute(Type baseType)
		{
			this.ValueType = baseType;
		}
	}
}
