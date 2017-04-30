using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public class PopupFieldAttribute : Attribute
	{
		public object[] values;

		public PopupFieldAttribute(params object[] values)
		{
			this.values = values;
		}
	}
}
