using FizzBuzzEnterpriseEdition.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzEnterpriseEdition.Bindings
{
	public class BindingKernel
	{
		// Todo: make this a hashset, catch duplicate key exception and rethrow our own "already bound" exception
		private List<Binding> bindings = new List<Binding>();

		public BindingKernel() { }

		public BindingKernel(IKernelBindings bindings)
		{
			bindings.Init(this);
		}

		public Binding Bind<T>()
		{
			Binding b = new Binding<T>();
			this.bindings.Add(b);
			return b;
		}

		public object Get<I>()
		{
			Type i = typeof(I);
			if (i.IsInterface)
			{
				Type t = bindings.FirstOrDefault(b => b.InterfaceType.FullName == i.FullName).ImplementationType;
				return Activator.CreateInstance(t);
			}
			else
				throw new ArgumentException("Argument must be an interface type");
		}
	}
}
