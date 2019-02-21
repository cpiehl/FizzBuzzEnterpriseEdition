using System;

namespace FizzBuzzEnterpriseEdition
{
	public class Binding
	{
		private Type interfaceType, implementationType;

		public Type InterfaceType
		{
			get
			{
				return this.interfaceType;
			}
			private set
			{
				if (value.IsInterface)
					this.interfaceType = value;
				else
					throw new ArgumentException("Argument must be an interface type");
			}
		}

		public Type ImplementationType
		{
			get
			{
				return this.implementationType;
			}
			private set
			{
				if (this.interfaceType.IsAssignableFrom(value))
					this.implementationType = value;
				else
					throw new ArgumentException($"Argument must inherit from interface {interfaceType.FullName}");
			}
		}

		internal Binding(Type interfaceType)
		{
			this.InterfaceType = interfaceType;
		}

		public void To<T>()
		{
			this.ImplementationType = typeof(T);
		}
	}

	public class Binding<T> : Binding
	{
		public Binding() : base(typeof(T)) { }
	}
}
