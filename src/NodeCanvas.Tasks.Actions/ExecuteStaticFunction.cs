using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using System;
using System.Reflection;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Script Control/Standalone Only"), Description("Execute a static function of up to 3 parameters and optionaly save the return value")]
	public class ExecuteStaticFunction : ActionTask
	{
		[IncludeParseVariables, SerializeField]
		private ReflectedWrapper functionWrapper;

		private MethodInfo targetMethod
		{
			get
			{
				return (this.functionWrapper == null || this.functionWrapper.GetMethod() == null) ? null : this.functionWrapper.GetMethod();
			}
		}

		protected override string info
		{
			get
			{
				if (this.functionWrapper == null)
				{
					return "No Method Selected";
				}
				if (this.targetMethod == null)
				{
					return string.Format("<color=#ff6457>* {0} *</color>", this.functionWrapper.GetMethodString());
				}
				BBParameter[] variables = this.functionWrapper.GetVariables();
				string text = string.Empty;
				string text2 = string.Empty;
				if (this.targetMethod.ReturnType == typeof(void))
				{
					for (int i = 0; i < variables.Length; i++)
					{
						text2 = text2 + ((i == 0) ? string.Empty : ", ") + variables[i].ToString();
					}
				}
				else
				{
					text = ((!variables[0].isNone) ? (variables[0] + " = ") : string.Empty);
					for (int j = 1; j < variables.Length; j++)
					{
						text2 = text2 + ((j == 1) ? string.Empty : ", ") + variables[j].ToString();
					}
				}
				return string.Format("{0}{1}.{2} ({3})", new object[]
				{
					text,
					this.targetMethod.DeclaringType.FriendlyName(),
					this.targetMethod.Name,
					text2
				});
			}
		}

		protected override string OnInit()
		{
			if (this.targetMethod == null)
			{
				return "ExecuteFunction Error";
			}
			string result;
			try
			{
				this.functionWrapper.Init(null);
				result = null;
			}
			catch
			{
				result = "ExecuteFunction Error";
			}
			return result;
		}

		protected override void OnExecute()
		{
			if (this.targetMethod == null)
			{
				base.EndAction(new bool?(false));
				return;
			}
			if (this.functionWrapper is ReflectedActionWrapper)
			{
				(this.functionWrapper as ReflectedActionWrapper).Call();
			}
			else
			{
				(this.functionWrapper as ReflectedFunctionWrapper).Call();
			}
			base.EndAction();
		}
	}
}
