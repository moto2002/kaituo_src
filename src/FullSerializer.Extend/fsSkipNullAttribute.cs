using System;

namespace FullSerializer.Extend
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class fsSkipNullAttribute : Attribute
	{
	}
}
