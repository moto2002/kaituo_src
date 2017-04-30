using NodeCanvas;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;
using XQ.Game.Util;

namespace Assets.Migration.Scripts.Node.Composite
{
	[Category("✫ GOG/Compostors"), Icon("ProbabilitySelector", false), Name("Random selector")]
	public class RandomSelector : BTComposite
	{
		public List<BBParameter<float>> childWeights = new List<BBParameter<float>>();

		public BBParameter<float> failChance = new BBParameter<float>();

		private float probability;

		private float currentProbability;

		private List<int> failedIndeces = new List<int>();

		public override string name
		{
			get
			{
				return string.Format("<color=#b3ff7f>{0}</color>", base.name.ToUpper());
			}
		}

		public override void OnChildConnected(int index)
		{
			this.childWeights.Insert(index, new BBParameter<float>
			{
				value = 1f,
				bb = base.graphBlackboard
			});
		}

		public override void OnChildDisconnected(int index)
		{
			this.childWeights.RemoveAt(index);
		}

		public override void OnGraphStarted()
		{
			this.OnReset();
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			this.currentProbability = this.probability;
			for (int i = 0; i < base.outConnections.Count; i++)
			{
				if (!this.failedIndeces.Contains(i))
				{
					if (this.currentProbability > this.childWeights[i].value)
					{
						this.currentProbability -= this.childWeights[i].value;
					}
					else
					{
						base.status = base.outConnections[i].Execute(agent, blackboard);
						if (base.status == Status.Success || base.status == Status.Running)
						{
							return base.status;
						}
						if (base.status == Status.Failure)
						{
							this.failedIndeces.Add(i);
							float num = this.GetTotal();
							for (int j = 0; j < this.failedIndeces.Count; j++)
							{
								num -= this.childWeights[j].value;
							}
							this.probability = ToolUtil.Random(0f, num);
							return Status.Running;
						}
					}
				}
			}
			return Status.Failure;
		}

		protected override void OnReset()
		{
			this.failedIndeces.Clear();
			this.probability = ToolUtil.Random(0f, this.GetTotal());
		}

		private float GetTotal()
		{
			float num = this.failChance.value;
			foreach (BBParameter<float> current in this.childWeights)
			{
				num += current.value;
			}
			return num;
		}
	}
}