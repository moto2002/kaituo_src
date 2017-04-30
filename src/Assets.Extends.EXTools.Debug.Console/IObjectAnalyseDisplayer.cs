using System;

namespace Assets.Extends.EXTools.Debug.Console
{
	public interface IObjectAnalyseDisplayer
	{
		void ShowNewObject(object obj, string objName);

		bool Back();

		void Show();
	}
}
