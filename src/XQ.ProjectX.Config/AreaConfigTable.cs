using Assets.Tools.Script.Editortool;
using Assets.Tools.Script.Editortool.Reader;
using System;
using System.Collections.Generic;

namespace XQ.ProjectX.Config
{
	public class AreaConfigTable : TextConfigTable<AreaConfigTable, AreaConfig, TableConfigReader<AreaConfigTable, AreaConfig>>
	{
		public List<AreaConfig> Configs;
	}
}
