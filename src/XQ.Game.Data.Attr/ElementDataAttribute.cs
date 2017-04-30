using System;

namespace XQ.Game.Data.Attr
{
	[NonLuaFile]
	public class ElementDataAttribute : Attribute
	{
		public Type DataType;

		public ElementDataAttribute(Type type)
		{
			this.DataType = type;
		}
	}
}
