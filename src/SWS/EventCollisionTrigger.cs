using System;
using UnityEngine;
using UnityEngine.Events;

namespace SWS
{
	public class EventCollisionTrigger : MonoBehaviour
	{
		public bool onTrigger = true;

		public bool onCollision = true;

		public UnityEvent myEvent;

		private void OnTriggerEnter(Collider other)
		{
			if (!this.onTrigger)
			{
				return;
			}
			this.myEvent.Invoke();
		}

		private void OnCollisionEnter(Collision other)
		{
			if (!this.onCollision)
			{
				return;
			}
			this.myEvent.Invoke();
		}

		public void ApplyForce(int power)
		{
			Vector3 position = base.transform.position;
			float num = 5f;
			Collider[] array = Physics.OverlapSphere(position, num);
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Collider collider = array2[i];
				navMove component = collider.GetComponent<navMove>();
				if (component != null)
				{
					component.Stop();
					collider.GetComponent<NavMeshAgent>().enabled = false;
					collider.isTrigger = false;
				}
				Rigidbody component2 = collider.GetComponent<Rigidbody>();
				if (component2 != null)
				{
					component2.AddExplosionForce((float)power, position, num, 100f);
				}
			}
		}
	}
}
