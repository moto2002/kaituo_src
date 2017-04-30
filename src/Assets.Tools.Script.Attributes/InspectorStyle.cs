using System;

namespace Assets.Tools.Script.Attributes
{
	public class InspectorStyle : Attribute
	{
		public string Name;

		public string ParserName;

		public object[] ParserAgrs;

		public InspectorStyle(string name)
		{
			this.Name = name;
		}

		public InspectorStyle(string name, string parserName)
		{
			this.Name = name;
			this.ParserName = parserName;
		}

		public InspectorStyle(string name, string parserName, params object[] parserAgrs)
		{
			this.ParserAgrs = parserAgrs;
			this.Name = name;
			this.ParserName = parserName;
		}
	}
}
