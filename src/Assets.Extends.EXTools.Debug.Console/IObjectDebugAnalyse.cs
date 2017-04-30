using System;

namespace Assets.Extends.EXTools.Debug.Console
{
	public interface IObjectDebugAnalyse
	{
		void Show(object obj, string objName, ObjectAnalyseDisplayer displayer);

		bool IsActiveBy(object obj);
	}
}
