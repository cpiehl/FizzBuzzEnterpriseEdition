using System;

namespace FizzBuzzEnterpriseEdition
{
	public class Binding
	{
		private Type interfaceType, implementationType;

		/// <summary>
		/// This binding's interface type.
		/// </summary>
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

		/// <summary>
		/// This binding's implementation type.
		/// </summary>
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

		/// <summary>
		/// Finish binding to implementation type T.
		/// </summary>
		/// <typeparam name="T">Implementation Type.</typeparam>
		/// <returns>Bound Binding object.</returns>
		public Binding To<T>()
		{
			this.ImplementationType = typeof(T);
			return this;
		}
	}

	public class Binding<T> : Binding
	{
		public Binding() : base(typeof(T)) { }
	}
}
