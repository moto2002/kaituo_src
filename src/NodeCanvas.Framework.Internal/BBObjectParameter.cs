using System;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	public class BBObjectParameter : BBParameter<object>
	{
		[SerializeField]
		private Type _type;

		public override Type varType
		{
			get
			{
				return this._type;
			}
		}

		public BBObjectParameter()
		{
			this.SetType(typeof(object));
		}

		public BBObjectParameter(Type t)
		{
			this.SetType(t);
		}

		public void SetType(Type t)
		{
			if (t == null)
			{
				t = typeof(object);
			}
			if (t != this._type)
			{
				this._value = null;
			}
			this._type = t;
		}
	}
}
