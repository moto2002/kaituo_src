using NodeCanvas.Framework;
using System;

namespace Assets.Scripts.Tool
{
	public static class BlackboardHelper
	{
		public static void SetOrAddValue(this IBlackboard blackboard, string name, object value)
		{
			Variable variable = blackboard.GetVariable(name, null);
			if (variable == null)
			{
				blackboard.AddVariable(name, value.GetType());
				variable = blackboard.GetVariable(name, null);
			}
			variable.value = value;
		}

		public static void SetOrAddValue(this IBlackboard blackboard, string name, object value, Type valueType)
		{
			Variable variable = blackboard.GetVariable(name, null);
			if (variable == null)
			{
				blackboard.AddVariable(name, valueType);
				variable = blackboard.GetVariable(name, null);
			}
			try
			{
				variable.value = value;
			}
			catch (Exception)
			{
				DebugConsole.Log(new object[]
				{
					variable.name,
					variable.varType
				});
				throw;
			}
		}
	}
}
