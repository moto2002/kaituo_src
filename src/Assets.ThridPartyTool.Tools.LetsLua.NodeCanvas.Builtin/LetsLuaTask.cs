using NodeCanvas.Framework;
using System;

namespace Assets.ThridPartyTool.Tools.LetsLua.NodeCanvas.Builtin
{
	public abstract class LetsLuaTask : Task
	{
		protected void SetChildTaskOwnerSystem(Task task)
		{
			if (task != null)
			{
				task.SetOwnerSystem(base.ownerSystem);
			}
		}
	}
}
