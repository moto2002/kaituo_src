using System;

namespace FullSerializer.Internal
{
	public struct fsVersionedType
	{
		public fsVersionedType[] Ancestors;

		public string VersionString;

		public Type ModelType;

		public object Migrate(object ancestorInstance)
		{
			return Activator.CreateInstance(this.ModelType, new object[]
			{
				ancestorInstance
			});
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"fsVersionedType [ModelType=",
				this.ModelType,
				", VersionString=",
				this.VersionString,
				", Ancestors.Length=",
				this.Ancestors.Length,
				"]"
			});
		}

		public override bool Equals(object obj)
		{
			return obj is fsVersionedType && this.ModelType == ((fsVersionedType)obj).ModelType;
		}

		public override int GetHashCode()
		{
			return this.ModelType.GetHashCode();
		}

		public static bool operator ==(fsVersionedType a, fsVersionedType b)
		{
			return a.ModelType == b.ModelType;
		}

		public static bool operator !=(fsVersionedType a, fsVersionedType b)
		{
			return a.ModelType != b.ModelType;
		}
	}
}
