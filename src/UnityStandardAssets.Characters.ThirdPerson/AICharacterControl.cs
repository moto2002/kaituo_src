using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(ThirdPersonCharacter)), RequireComponent(typeof(NavMeshAgent))]
	public class AICharacterControl : MonoBehaviour
	{
		public Transform target;

		public NavMeshAgent agent
		{
			get;
			private set;
		}

		public ThirdPersonCharacter character
		{
			get;
			private set;
		}

		private void Start()
		{
			this.agent = base.GetComponentInChildren<NavMeshAgent>();
			this.character = base.GetComponent<ThirdPersonCharacter>();
			this.agent.updateRotation = false;
			this.agent.updatePosition = true;
		}

		private void Update()
		{
			if (this.target != null)
			{
				this.agent.SetDestination(this.target.position);
				this.character.Move(this.agent.desiredVelocity, false, false);
			}
			else
			{
				this.character.Move(Vector3.zero, false, false);
			}
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	}
}
