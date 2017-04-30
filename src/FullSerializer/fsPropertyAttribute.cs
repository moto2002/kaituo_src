using System;

namespace FullSerializer
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class fsPropertyAttribute : Attribute
	{
		public string Name;

		public Type Converter;

		public fsPropertyAttribute() : this(string.Empty)
		{
		}

		public fsPropertyAttribute(string name)
		{
			this.Name = name;
		}
	}
}
